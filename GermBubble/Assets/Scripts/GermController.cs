using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GermController : MonoBehaviour
{
    public Image germ1;  // Reference to the Germ 1 Image UI element
    public Image germ2;  // Reference to the Germ 2 Image UI element
    public Image bub1;   // Reference to the Bub 1 Image UI element
    public Image bub2;   // Reference to the Bub 2 Image UI element
    public Image bub3;
    public Image bub4;
    public Image bub5;
    public Image bub6;
    
    
    public float moveDuration = 3f;  // Duration for moving Germ 1
    public Vector3 moveDistance = new Vector3(200f, 0f, 0f); // How far Germ 1 will move 
    public float germ2MoveAmount = 50f;  // How much Germ 2 moves to the right 

    public float scaleDuration = 2f;  // Time it takes for Germ 2 to grow
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // The scale that Germ 2 will grow to
    public Vector3 bub2TargetScale = new Vector3(3f, 3f, 3f); // The scale Bub 2 will grow to (larger than Germ 2)

    public float bub1MoveDuration = 4.5f;  // Duration for Bub 1 to move (slower than Germs)
    public Vector3 bub1TargetScale = new Vector3(3f, 3f, 3f);  // Bub 1 target scale, 1.5 times bigger than its original size
    public float bub1DelayStart = 1f;  // Delay before Bub 1 starts moving

    void Start()
    {
        germ2.gameObject.SetActive(false); // Initially hide Germ 2
        bub2.gameObject.SetActive(false);  // Initially hide Bub 2
        bub3.gameObject.SetActive(false);
        bub4.gameObject.SetActive(false);
        bub5.gameObject.SetActive(false);
        bub6.gameObject.SetActive(false);
        // Make Bub 1 hidden initially
        bub1.gameObject.SetActive(false); // Bub 1 will be hidden until Germ 1 is unhidden
        
        // Start the delayed animation
        StartCoroutine(WaitAndActivate()); 

        // Hide Germ 1 initially
        germ1.gameObject.SetActive(false);
    }

    // Coroutine to wait for 7 seconds before starting the animation
    IEnumerator WaitAndActivate()
    {
        // Wait for 7 seconds before starting the animation
        yield return new WaitForSeconds(7f);
        
        // Debug log to indicate the wait is over
        Debug.Log("7 seconds have passed. Activating animation!");

        // Start the animation for Germs and Bub1
        StartCoroutine(AnimateGerms());
        
        // Make Germ 1 visible
        germ1.gameObject.SetActive(true);

        // Start Bub1 catching up to Germ 1 after a delay
        StartCoroutine(AnimateBub1());
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

        // Move Germ 2 slightly to the right
        Vector3 germ2StartPosition = germ2.transform.position;
        Vector3 germ2TargetPosition = germ2StartPosition + new Vector3(germ2MoveAmount, 0f, 0f);
        timeElapsed = 0f;

        // Move Germ 2 to the new position
        while (timeElapsed < moveDuration)
        {
            germ2.transform.position = Vector3.Lerp(germ2StartPosition, germ2TargetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Germ 2 finishes at the target position
        germ2.transform.position = germ2TargetPosition;

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
        
        // Now, start animating Bub 2 after Germ 2 finishes
        StartCoroutine(AnimateBub2());
    }

    // Coroutine to animate Bub1 catching up to Germ 1 after a delay
    IEnumerator AnimateBub1()
    {
        // Wait for Bub1 to start after the delay
        yield return new WaitForSeconds(bub1DelayStart);

        // Make Bub 1 visible after the delay
        bub1.gameObject.SetActive(true);

        // Start Bub1 further left of Germ 1 (off-screen position to start)
        Vector3 bub1StartPosition = bub1.transform.position + new Vector3(-300f, 0f, 0f); // Start further left
        Vector3 bub1TargetPosition = germ1.transform.position + new Vector3(0f, 0f, 0f); // Bub1 targets the position of Germ 1

        float timeElapsed = 0f;

        // While Germ1 is moving, we update Bub1's position to catch up
        while (timeElapsed < bub1MoveDuration)
        {
            // While Bub 1 is catching up, update its position towards Germ 1's current position
            bub1.transform.position = Vector3.Lerp(bub1StartPosition, germ1.transform.position, timeElapsed / bub1MoveDuration);
            timeElapsed += Time.deltaTime;

            // Make sure Bub 1 follows Germ 1's movement, even while Germ 1 is in motion
            bub1StartPosition = bub1.transform.position;  // Update Bub 1's start position to its new location

            yield return null;
        }

        // Ensure Bub 1 finishes at the same target position as Germ 1
        bub1.transform.position = germ1.transform.position;

        // Now scale up Bub 1 to 1.5 times its original size
        Vector3 initialBub1Scale = bub1.transform.localScale;
        timeElapsed = 0f;

        while (timeElapsed < scaleDuration)
        {
            bub1.transform.localScale = Vector3.Lerp(initialBub1Scale, bub1TargetScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Bub 1 ends at the target scale (1.5 times bigger)
        bub1.transform.localScale = bub1TargetScale;
    }

    // Coroutine to animate Bub2 getting bigger than Germ 2
    IEnumerator AnimateBub2()
    {
        // Start Bub2 from a position far left of Germ2 (or a different position)
        Vector3 bub2StartPosition = bub2.transform.position + new Vector3(-200f, 0f, 0f); // Start further left
        Vector3 bub2TargetPosition = germ2.transform.position + new Vector3(germ2MoveAmount, 0f, 0f); // Bub2 targets the new position of Germ2

        // Duration for Bub2 to move to the target position
        float timeElapsed = 0f;
        while (timeElapsed < moveDuration)
        {
            bub2.transform.position = Vector3.Lerp(bub2StartPosition, bub2TargetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Bub2 finishes at the target position
        bub2.transform.position = bub2TargetPosition;

        // Make Bub2 visible
        bub2.gameObject.SetActive(true);

        // Scale up Bub2 to a size larger than Germ2
        Vector3 initialBub2Scale = bub2.transform.localScale;
        timeElapsed = 0f;

        while (timeElapsed < scaleDuration)
        {
            bub2.transform.localScale = Vector3.Lerp(initialBub2Scale, bub2TargetScale, timeElapsed / scaleDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure Bub2 finishes at the target scale (larger than Germ2)
        bub2.transform.localScale = bub2TargetScale;

        // Hide Germ 2 after Bub 2 finishes growing
        germ2.gameObject.SetActive(false);
        
        bub3.gameObject.SetActive(true);
        bub4.gameObject.SetActive(true);
        bub5.gameObject.SetActive(true);
        bub6.gameObject.SetActive(true);
    }
}
