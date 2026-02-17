using UnityEngine;

public class BallTypeManager : MonoBehaviour
{
    public static BallTypeManager instance;

    public enum BallType
    {
        None,
        ShortBall,
        FullBall,
        GoodLength
    }

    public BallType selectedBallType = BallType.None;

    void Awake()
    {
        instance = this;
    }

    public void SetBallType(int type)
    {
        selectedBallType = (BallType)type;
        Debug.Log("Selected ball type: " + selectedBallType);
    }
}
