using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class WatchTeleportManager : MonoBehaviour
{
    public TeleportationProvider teleportationProvider;
    public Transform returnPoint;

    public void TeleportToSpacecraft()
    {
        if (teleportationProvider == null || returnPoint == null)
        {
            Debug.LogError("WatchTeleportManager is missing a reference.");
            return;
        }

        TeleportRequest request = new TeleportRequest
        {
            destinationPosition = returnPoint.position,
            destinationRotation = returnPoint.rotation,
            matchOrientation = MatchOrientation.TargetUpAndForward
        };

        teleportationProvider.QueueTeleportRequest(request);
    }
}