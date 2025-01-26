using UnityEngine;

public class BubbleLeft : MonoBehaviour
{
    public float respawnXPosition = -1000f; // X position where the image respawns (can be off-screen)
    public float speed = 5f;                   // Speed at which the bubble moves
    public float spinSpeed = 100f;             // Speed of rotation (degrees per second)
    private RectTransform bubbleRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        bubbleRectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the Image
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bubble horizontally
        bubbleRectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);

        // Rotate the bubble (spinning effect)
        bubbleRectTransform.Rotate(0, 0, spinSpeed * Time.deltaTime); // Rotate around Z-axis

        // Check if the bubble has gone off the screen to the right
        if (bubbleRectTransform.anchoredPosition.x > Screen.width)
        {
            // Reset to the left side of the screen
            float bubbleWidth = bubbleRectTransform.rect.width;
            bubbleRectTransform.anchoredPosition = new Vector2(respawnXPosition, bubbleRectTransform.anchoredPosition.y);
        }
    }
}
