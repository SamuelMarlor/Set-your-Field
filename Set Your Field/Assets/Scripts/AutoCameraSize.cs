using UnityEngine;

public class AutoCameraSize : MonoBehaviour
{
    public float baseSize = 19f;
    public float referenceAspect = 16f / 9f;

    void LateUpdate()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        Camera cam = GetComponent<Camera>();

        if (currentAspect < referenceAspect)
        {
            float scaleFactor = referenceAspect / currentAspect;
            cam.orthographicSize = baseSize * scaleFactor;
        }
        else
        {
            cam.orthographicSize = baseSize;
        }
    }
}