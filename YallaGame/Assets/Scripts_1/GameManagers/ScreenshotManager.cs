using System;
using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour
{
    public Camera screenshotCamera; // Виртуальная камера для скриншота
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

        // Включаем камеру (если она отключена)
        screenshotCamera.gameObject.SetActive(true);

        // Подождем один кадр, чтобы камера обновилась
        yield return new WaitForEndOfFrame();

        // Создаём RenderTexture
        RenderTexture renderTex = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        screenshotCamera.targetTexture = renderTex;

        // Рендерим камеру вручную
        screenshotCamera.Render();

        // Копируем изображение в Texture2D
        RenderTexture.active = renderTex;
        Texture2D screenshot = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
        screenshot.Apply();

        // Очищаем ресурсы
        screenshotCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTex);

        // Сохраняем файл PNG
        byte[] bytes = screenshot.EncodeToPNG();
        string filename = Path.Combine(Application.persistentDataPath, "screenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
        File.WriteAllBytes(filename, bytes);
        Debug.Log("Screenshot saved to: " + filename);
        Debug.Log("Скриншот находится здесь: " + Application.persistentDataPath);


        // Выключаем камеру обратно
        screenshotCamera.gameObject.SetActive(false);

        isCapturing = false;
    }
}
