using UnityEngine;
using UnityEditor;

public class RemapGloveBones : EditorWindow
{
    private SkinnedMeshRenderer gloveMesh;
    private Transform trackedRoot;

    [MenuItem("Tools/Glove Bone Remapper")]
    public static void ShowWindow()
    {
        GetWindow<RemapGloveBones>("Glove Bone Remapper");
    }

    private void OnGUI()
    {
        GUILayout.Label("Glove Bone Remapper", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        gloveMesh = (SkinnedMeshRenderer)EditorGUILayout.ObjectField(
            "Glove Mesh",
            gloveMesh,
            typeof(SkinnedMeshRenderer),
            true
        );

        trackedRoot = (Transform)EditorGUILayout.ObjectField(
            "Tracked Skeleton Root",
            trackedRoot,
            typeof(Transform),
            true
        );

        EditorGUILayout.Space();

        if (GUILayout.Button("Remap Bones"))
        {
            RemapBones();
        }
    }

    private void RemapBones()
    {
        if (gloveMesh == null)
        {
            Debug.LogError("Glove Mesh is not assigned.");
            return;
        }

        if (trackedRoot == null)
        {
            Debug.LogError("Tracked Skeleton Root is not assigned.");
            return;
        }

        Transform[] oldBones = gloveMesh.bones;
        Transform[] newBones = new Transform[oldBones.Length];

        int remapped = 0;
        int failed = 0;

        for (int i = 0; i < oldBones.Length; i++)
        {
            Transform oldBone = oldBones[i];

            if (oldBone == null)
            {
                failed++;
                continue;
            }

            string targetName = oldBone.name;

            // Remove the "_Rig" suffix from our FBX bone names.
            if (targetName.EndsWith("Rig") || targetName.EndsWith("rig"))
            {
                targetName = targetName.Substring(
                0,
                targetName.Length - 3
            );

                Transform matchingBone = FindChildRecursive(
                trackedRoot,
                targetName
            );

                if (matchingBone != null)
                {
                    newBones[i] = matchingBone;
                    remapped++;
                }
                else
                {
                    newBones[i] = oldBone;
                    failed++;

                    Debug.LogWarning(
                        "Could not find tracked bone: " + targetName
                    );
                }
            }

            Undo.RecordObject(gloveMesh, "Remap Glove Bones");

            gloveMesh.bones = newBones;

            // Also use the tracked wrist as the root.
            Transform trackedWrist = FindChildRecursive(
                trackedRoot,
                "L_Wrist"
            );

            if (trackedWrist != null)
            {
                gloveMesh.rootBone = trackedWrist;
            }

            EditorUtility.SetDirty(gloveMesh);

            Debug.Log(
                "Glove bone remapping complete. " +
                "Remapped: " + remapped +
                " | Failed: " + failed
            );
        }
    }

    private Transform FindChildRecursive(
        Transform parent,
        string targetName
    )
    {
        if (parent.name == targetName)
            return parent;

        foreach (Transform child in parent)
        {
            Transform result = FindChildRecursive(
                child,
                targetName
            );

            if (result != null)
                return result;
        }

        return null;
    }
}