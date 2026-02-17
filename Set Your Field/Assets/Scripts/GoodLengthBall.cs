using UnityEngine;

public class GoodLengthBall : MonoBehaviour
{
    public float speed = 6f;
    public Transform batterPoint;
    public Transform startPoint;

    // Catch system
    public float catchRadius = 2f;
    public float catchChance = 0.5f;

    private bool hasTriggered = false;
    private bool ballActive = false;
    private Vector2 direction = Vector2.down;
    public bool isHighBall = false;

    void Update()
    {
        if (!ballActive)
            return;

        transform.Translate(direction * speed * Time.deltaTime);

        CheckForCatch();
    }

    public void StartBall()
    {
        if (BallTypeManager.instance.selectedBallType != BallTypeManager.BallType.GoodLength)
            return;

        ballActive = true;
    }

    public void ResetBall()
    {
        ballActive = false;
        hasTriggered = false;

        transform.position = startPoint.position;
        direction = Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Batter hits the ball
        if (!hasTriggered && collision.transform == batterPoint)
        {
            hasTriggered = true;
            ApplyGoodLengthHit();
        }

        // Boundary logic
        if (collision.CompareTag("boundary"))
        {
            BallHitBoundary();
        }
    }

    void ApplyGoodLengthHit()
    {
        direction = GetGoodLengthHitDirection() * Random.Range(0.9f, 1.3f);
        isHighBall = Random.value < 0.3f;   // 30% chance of a high shot
    }

    Vector2 GetGoodLengthHitDirection()
    {
        float roll = Random.value;

        if (roll < 0.4f)
            return new Vector2(Random.Range(-0.2f, 0.2f), 1f).normalized;

        if (roll < 0.7f)
            return new Vector2(Random.Range(0.3f, 0.8f), 0.8f).normalized;

        if (roll < 0.9f)
            return new Vector2(Random.Range(-0.8f, -0.3f), 0.5f).normalized;

        return new Vector2(0, -0.2f).normalized;
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
                if (isHighBall && fielder.isOuterRing)
                {
                    TryCatchBall(fielder);
                    return;
                }
            }
        }
    }

    void TryCatchBall(PlacedFielder fielder)
    {
        float roll = Random.value;

        if (roll <= catchChance)
        {
            Debug.Log("Catch successful!");
            BallCaught(fielder);
        }
        else
        {
            Debug.Log("Catch dropped!");
            ResetBall();   // ⭐ NEW — reset even when dropped
        }
    }

    void BallCaught(PlacedFielder fielder)
    {
        ResetBall();
    }

    void BallHitBoundary()
    {
        Debug.Log("boundary!");
        ResetBall();
    }
}