using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class FielderPlacementManager : MonoBehaviour
{
    public Camera cam;
    public GameObject fielderPrefab;
    public int maxFielders = 9;
    public int fieldersLeft = 9;
    public Transform batter;
    public TMP_Text fieldersRemainingText;
    public UnityEngine.UI.Button confirmButton;
    public ShortBallBounce ballScript;
    public PlacedFielder pf;

    public int fieldersPlaced = 0;
    private List<GameObject> SpawnedFielders = new List<GameObject>();

    

    void Update()
    {
        if (BallTypeManager.instance.selectedBallType == BallTypeManager.BallType.None)
        {
            Debug.Log("Select a ball type first!");
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            TryPlaceFielder();
        }

        fieldersRemainingText.text = fieldersLeft.ToString();
    }

    public void RegisterPlacement()
    {
        fieldersLeft--;
        fieldersPlaced++;
    }

    void TryPlaceFielder()
    {
        // Global limit
        if (fieldersPlaced >= maxFielders)
            return;

        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        // Only place fielders if clicking the INNER RING
        if (hit.collider == null || !hit.collider.CompareTag("InnerRing"))
            return;

        GameObject newFielder = Instantiate(fielderPrefab, worldPos, Quaternion.identity);

        // Flip based on batter position
        Vector3 scale = newFielder.transform.localScale;
        if (newFielder.transform.position.x < batter.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        newFielder.transform.localScale = scale;

       

        SpawnedFielders.Add(newFielder);
        fieldersPlaced++;
        fieldersLeft--;
        pf.isInnerRing = true;
        pf.isOuterRing = false;
    }

    public BallManager ballManager;

    public void ConfirmFielders()
    {
        if (fieldersPlaced < maxFielders)
        {
            Debug.Log("You must place all 9 fielders first.");
            return;
        }

        // All fielders placed — start the selected ball type
        ballManager.Confirm();
    }


}
        

    
    //void PlaceFielder(FielZone zone)
    //{
    //    GameObject fielder = Instantiate(fielderPrefab, zone.transform.position, Quaternion.identity);
    //    zone.isOccupied = true;
    //    fieldersPlaced++;
    //}

