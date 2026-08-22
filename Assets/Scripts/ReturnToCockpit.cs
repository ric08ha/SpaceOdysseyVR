using UnityEngine;

public class ReturnToCockpit : MonoBehaviour
{
    [Header("Player & Destination")]
    public GameObject xrOrigin;
    public Transform cockpitSpawnPoint;

    public void TeleportToSeat()
    {
        // Briefly turn off physics so we can force a teleport
        CharacterController controller = xrOrigin.GetComponent<CharacterController>();
        if (controller != null) controller.enabled = false;

        // Move the player to the cockpit
        xrOrigin.transform.position = cockpitSpawnPoint.position;
        xrOrigin.transform.rotation = cockpitSpawnPoint.rotation;

        // Turn physics back on
        if (controller != null) controller.enabled = true;
    }
}   