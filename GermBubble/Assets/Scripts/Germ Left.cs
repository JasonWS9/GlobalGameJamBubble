using UnityEngine;

public class GermLeft : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float respawnXPosition = 1000f; // X position where the image respawns (can be off-screen)
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the Image
    }

    void Update()
    {
        // Move the UI Image to the left side
        if (rectTransform.anchoredPosition.x > -Screen.width / 2)
        {
            // Move the Image towards the left (negative direction of the x-axis)
            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x - moveSpeed * Time.deltaTime,
                rectTransform.anchoredPosition.y
            );
        }
        else
        {
            // Once the image goes off-screen (to the left), respawn it on the right side
            respawn();
        }
    }

    void respawn()
    {
        // Set the position of the image to the right side (or any desired position)
        rectTransform.anchoredPosition = new Vector2(respawnXPosition, rectTransform.anchoredPosition.y);
    }
}