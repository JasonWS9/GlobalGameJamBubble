using UnityEngine;

public class BubbleUp : MonoBehaviour
{
    public float speed = 5f; // Speed of floating
    public float horizontalRange = 200f; // Range of horizontal movement
    public float respawnHeight = 600f; // Y Position for respawn
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Temporarily set anchors to the top-left to avoid default center-based behavior
        rectTransform.anchorMin = new Vector2(0, 1); // Top-left corner
        rectTransform.anchorMax = new Vector2(0, 1); // Top-left corner
        rectTransform.pivot = new Vector2(0, 1); // Top-left pivot

        // Set the initial position to X = -400 and Y = -488 (move more right)
        rectTransform.anchoredPosition = new Vector2(-400, -488); // Adjust X for more rightward start
    }

    void Update()
    {
        // Float left and right
        float newX = Mathf.PingPong(Time.time * speed, horizontalRange * 2) - horizontalRange;
        
        // Float upwards by modifying Y position over time
        float newY = rectTransform.anchoredPosition.y + speed * Time.deltaTime;

        rectTransform.anchoredPosition = new Vector2(newX, newY);

        // Check if the UI element has gone off the screen and respawn it
        if (rectTransform.anchoredPosition.y > respawnHeight)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Only reset Y when it goes off-screen, but make sure we're not affecting X position
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -488); // Keep the X value, reset Y
    }
}