using UnityEngine;

public class BatterHandManager : MonoBehaviour
{
    public Transform batter;   // your batter object
    public bool isLeftHanded = false;
    public Transform pitch;
    public Transform keeper;
    private Vector3 originalKeeperPos;

    void Start()
    {
       
    }

    public void SetLeftHand()
    {
        isLeftHanded = true;
        ApplyHandedness();
        ApplyRightHandPitchTransform();
       



    }

    public void SetRightHand()
    {
        isLeftHanded = false;
        ApplyHandedness();
        ApplyLeftHandPitchTransform();
        

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

   


}