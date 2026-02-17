using UnityEngine;

public class BatterHandManager : MonoBehaviour
{
    public Transform batter;   // your batter object
    public bool isLeftHanded = false;
    public Transform pitch;
    public Transform keeper;
    private Vector3 originalKeeperPos;
    private Vector3 originalKeeperRot;
    private Vector3 originalKeeperScale;

    void Start()
    {
        originalKeeperPos = keeper.position;
        originalKeeperRot = keeper.rotation.eulerAngles;
        originalKeeperScale = keeper.localScale;
    }

    public void SetLeftHand()
    {
        isLeftHanded = true;
        ApplyHandedness();
        ApplyRightHandPitchTransform();
        ApplyRightHandKeeperTransform();



    }

    public void SetRightHand()
    {
        isLeftHanded = false;
        ApplyHandedness();
        ApplyLeftHandPitchTransform();
        ApplyLeftHandKeeperTransform();


    }


    void ApplyHandedness()
    {
        Vector3 scale = batter.localScale;

        if (isLeftHanded)
            scale.x = Mathf.Abs(scale.x);   // face left
        else
            scale.x = -Mathf.Abs(scale.x);  // face right

        batter.localScale = scale;
    }

    void ApplyLeftHandPitchTransform()
    {
        pitch.position = new Vector3(-138.9f, 6.86f, 0.1f);
        pitch.rotation = Quaternion.Euler(180f, 180f, 0f);
        pitch.localScale = new Vector3(-4.645042f, -4.296092f, 1f);
    }

    void ApplyRightHandPitchTransform()
    {
        pitch.position = new Vector3(-138.9f, 7.76f, 0.1f);
        pitch.rotation = Quaternion.Euler(180f, 180f, 0f);
        pitch.localScale = new Vector3(4.645042f, 4.296092f, 1f);
    }

    void ApplyLeftHandKeeperTransform()
    {
        keeper.position = new Vector3(0.3544338f, 2.166394f, -0.2000004f);
        keeper.rotation = Quaternion.Euler(0f, 0f, 0f);
        keeper.localScale = new Vector3(0.1049333f, 0.1108908f, 1f);
    }

    void ApplyRightHandKeeperTransform()
    {
        keeper.position = originalKeeperPos;
        keeper.rotation = Quaternion.Euler(originalKeeperRot);
        keeper.localScale = originalKeeperScale;
    }



}