using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class WatchTeleport : MonoBehaviour
{
    public TeleportationProvider teleportationProvider;
    public Transform returnPoint;

    public void TeleportToSpacecraft()
    {
        TeleportRequest request = new TeleportRequest
        {
            destinationPosition = returnPoint.position,
            destinationRotation = returnPoint.rotation,
            matchOrientation = MatchOrientation.TargetUpAndForward
        };

        teleportationProvider.QueueTeleportRequest(request);
    }
}