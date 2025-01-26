using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GermController : MonoBehaviour
{
    public Image germ1;  // Reference to the Germ 1 Image UI element
    public Image germ2;  // Reference to the Germ 2 Image UI element

    public float moveDuration = 3f;  // Duration for moving Germ 1
    public Vector3 moveDistance = new Vector3(200f, 0f, 0f); // How far Germ 1 will move (adjust X for movement)

    public float scaleDuration = 2f;  // Time it takes for Germ 2 to grow
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // The scale that Germ 2 will grow to

    void Start()
    {
        germ2.gameObject.SetActive(false); // Initially hide Germ 2

        // Start the delayed animation
        StartCoroutine(WaitAndActivate()); 
        
        // Hide Germ 1
        germ1.gameObject.SetActive(false);
    }

    // Coroutine to wait for 5 seconds before starting the animation
    IEnumerator WaitAndActivate()
    {
        // Wait for 5 seconds before starting the animation
        yield return new WaitForSeconds(7f);
        
        // Debug log to indicate the wait is over
        Debug.Log("7 seconds have passed. Activating animation!");

        // Start the animation
        StartCoroutine(AnimateGerms());
        
        germ1.gameObject.SetActive(true);
    }

    // Coroutine to animate Germ 1 and Germ 2
    IEnumerator AnimateGerms()
    {
        // Move Germ 1 to the right over the course of 3 seconds
        Vector3 startPosition = germ1.transform.position;
        Vector3 targetPosition = startPosition + moveDistance;
        float timeElapsed = 0f;

        while (timeElapsed < moveDuration)
        {
            germ1.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Germ 1 finishes at the target position
        germ1.transform.position = targetPosition;

        germ1.gameObject.SetActive(false);

        // Make Germ 2 visible
        germ2.gameObject.SetActive(true);

        // Scale up Germ 2
        Vector3 initialScale = germ2.transform.localScale;
        timeElapsed = 0f;

        while (timeElapsed < scaleDuration)
        {
            germ2.transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Germ 2 ends at the target scale
        germ2.transform.localScale = targetScale;
    }
}
