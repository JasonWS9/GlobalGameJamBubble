using UnityEngine;

public class RotatingScript : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    // Update is called once per frame
    void Update()
    {
        // Rotate the UI Image around its own axis (z-axis)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}