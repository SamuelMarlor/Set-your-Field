using UnityEngine;

public class ShortBallBounce : MonoBehaviour
{
    public float speed = 6f;
    public Transform batterPoint;

    // Catch system
    public float catchRadius = 2f;   // how close the ball must be
    public float catchChance = 0.6f;   // 60% chance
    public Transform startPoint;

    private bool hasTriggered = false;
    private bool ballActive = false;
    public bool isHighBall = false;

    private Vector2 direction = Vector2.down;

    void Update()
    {
        if (!ballActive)
            return;

        transform.Translate(direction * speed * Time.deltaTime);

        CheckForCatch();
    }

    public void StartBall()
    {
        ballActive = true;
    }

    public void ResetBall()
    {
        ballActive = false;
        hasTriggered = false;

        // Move ball back to start
        transform.position = startPoint.position;

        // Reset direction
        direction = Vector2.down;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.transform == batterPoint)
        {
            hasTriggered = true;
            ApplyRandomAngle();
        }

        if (collision.CompareTag("boundary"))
        {
            BallHitBoundary();
        }

    }

    void ApplyRandomAngle()
    {
        float angle = GetRandomAngle();
        direction = Quaternion.Euler(0, 0, angle) * direction;

        // 40% chance the ball goes high
        isHighBall = Random.value < 0.4f;
    }

    float GetRandomAngle()
    {
        float chance90 = 20f;
        float chance45 = 30f;

        float roll = Random.Range(0f, 100f);

        if (roll < chance90)
            return Random.value < 0.5f ? 90f : -90f;

        if (roll < chance90 + chance45)
            return Random.value < 0.5f ? 45f : -45f;

        else
            return Random.value < 0.5f ? 135f : -135f;
    }


    void CheckForCatch()
    {
        PlacedFielder[] fielders = FindObjectsOfType<PlacedFielder>();

        foreach (PlacedFielder fielder in fielders)
        {
            float distance = Vector2.Distance(transform.position, fielder.transform.position);

            if (distance <= catchRadius)
            {
                // INNER RING FIELDERS
                if (!isHighBall && fielder.isInnerRing)
                {
                    TryCatchBall(fielder);
                    return;
                }

                // OUTER RING FIELDERS
                if (fielder.isOuterRing)
                {
                    TryCatchBall(fielder);
                    return;
                }
            }
        }
    }

    void TryCatchBall(PlacedFielder fielder)
    {
        float roll = Random.value; // 0.0 to 1.0

        if (roll <= catchChance)
        {
            Debug.Log("Catch successful!");
            BallCaught(fielder);
        }
        else
        {
            Debug.Log("Catch dropped!");
        }
    }

    void BallCaught(PlacedFielder fielder)
    {
        // Stop the ball or destroy it
        ResetBall();
    }

    void BallHitBoundary()
    {
        Debug.Log("Ball hit the boundary!");
        ResetBall();
    }
}