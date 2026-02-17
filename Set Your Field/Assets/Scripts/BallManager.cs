using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject shortBall;
    public GameObject goodLengthBall;

    public void Confirm()
    {
        // Disable all balls first
        shortBall.SetActive(false);
        goodLengthBall.SetActive(false);

        // Enable only the selected ball type
        switch (BallTypeManager.instance.selectedBallType)
        {
            case BallTypeManager.BallType.ShortBall:
                shortBall.SetActive(true);
                shortBall.GetComponent<ShortBallBounce>().StartBall();
                break;

            case BallTypeManager.BallType.GoodLength:
                goodLengthBall.SetActive(true);
                goodLengthBall.GetComponent<GoodLengthBall>().StartBall();
                break;

            default:
                Debug.Log("No ball type selected!");
                break;
        }
    }
}