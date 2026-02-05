using UnityEngine;

public class BobUpDown : MonoBehaviour
{
    public float speed =1f;       // how fast it moves
    public float height = 0.01f;    // how far it moves up/down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * speed) * height;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}
