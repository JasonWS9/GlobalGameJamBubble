using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZoominText : MonoBehaviour
{
    private RectTransform uiTextRectTransform;
    private Vector3 originalScale;
    public float zoomFactor = 1.5f; // How much it zooms out (scale factor)
    public float zoomDuration = 2f; // Duration for zooming out or in

    void Start()
    {
        uiTextRectTransform = GetComponent<RectTransform>();
        originalScale = uiTextRectTransform.localScale;
        StartCoroutine(ZoomText());
    }

    IEnumerator ZoomText()
    {
        while (true)
        {
            // Zoom out
            Vector3 zoomedOutScale = originalScale * zoomFactor;
            float elapsedTime = 0f;
            while (elapsedTime < zoomDuration)
            {
                uiTextRectTransform.localScale = Vector3.Lerp(originalScale, zoomedOutScale, elapsedTime / zoomDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            uiTextRectTransform.localScale = zoomedOutScale;

            // Wait for 4 seconds at the zoomed-out state
            yield return new WaitForSeconds(4f);

            // Zoom in
            elapsedTime = 0f;
            while (elapsedTime < zoomDuration)
            {
                uiTextRectTransform.localScale = Vector3.Lerp(zoomedOutScale, originalScale, elapsedTime / zoomDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            uiTextRectTransform.localScale = originalScale;

            // Wait for 4 seconds at the original scale
            yield return new WaitForSeconds(4f);
        }
    }
}