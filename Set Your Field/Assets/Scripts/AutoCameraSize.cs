using UnityEngine;

public class AutoCameraSize : MonoBehaviour
{
    public float referenceWidth = 1920f;
    public float referenceHeight = 1080f;

    void Start()
    {
        float targetAspect = referenceWidth / referenceHeight;
        float windowAspect = (float)Screen.width / Screen.height;

        Camera cam = GetComponent<Camera>();

        if (windowAspect < targetAspect)
        {
            // Taller screen → zoom OUT
            float difference = targetAspect / windowAspect;
            cam.orthographicSize *= difference;
        }
    }
}
