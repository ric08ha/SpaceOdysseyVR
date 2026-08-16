using UnityEngine;

public class WatchTeleportButton : MonoBehaviour
{
    public void PressTeleport()
    {
        WatchTeleportManager manager = FindFirstObjectByType<WatchTeleportManager>();

        if (manager != null)
        {
            manager.TeleportToSpacecraft();
        }
        else
        {
            Debug.LogError("WatchTeleportManager not found in the scene.");
        }
    }
}