using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [Tooltip("How fast the planet rotates on its Y axis")]
    public float rotationSpeed = 2f;

    void Update()
    {
        // Slowly spins the object over time
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}