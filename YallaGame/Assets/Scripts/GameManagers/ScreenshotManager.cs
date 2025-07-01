using System;
using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public Camera screenshotCamera; // Virtual camera for screenshot
    public int resolutionWidth =  1080;
    public int resolutionHeight = 1920;

    private bool isCapturing = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            CaptureScreenshot();
        }
    }

    public void CaptureScreenshot()
    {
        if (isCapturing || screenshotCamera == null)
        {
            Debug.LogWarning("Screenshot is already being captured or screenshotCamera is not assigned.");
            return;
        }

        StartCoroutine(CaptureRoutine());
    }

    private System.Collections.IEnumerator CaptureRoutine()
    {
        isCapturing = true;

        // Enable the camera (if it’s disabled)
        screenshotCamera.gameObject.SetActive(true);

        // Wait one frame to let the camera update
        yield return new WaitForEndOfFrame();

        // Create a RenderTexture
        RenderTexture renderTex = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        screenshotCamera.targetTexture = renderTex;

        // Manually render the camera
        screenshotCamera.Render();

        // Copy the image into a Texture2D
        RenderTexture.active = renderTex;
        Texture2D screenshot = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
        screenshot.Apply();

        // Clean up resources
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTex);

        // Save PNG file
        byte[] bytes = screenshot.EncodeToPNG();
        string filename = Path.Combine(Application.persistentDataPath, "screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        File.WriteAllBytes(filename, bytes);
        Debug.Log("Screenshot saved to: " + filename);
        Debug.Log("Screenshot is located here: " + Application.persistentDataPath);

        // Disable the camera again
        screenshotCamera.gameObject.SetActive(false);

        isCapturing = false;
    }
}
