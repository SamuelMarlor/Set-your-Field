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


    private int fieldersPlaced = 0;
    private List<GameObject> SpawnedFielders = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fieldersRemainingText.text = "" + fieldersLeft;
    }



// Update is called once per frame
void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            TryPlaceFielder();
        }
        fieldersRemainingText.text = "" + fieldersLeft;
    }

    void TryPlaceFielder()
    {
        if (fieldersPlaced >= maxFielders)
            return;

        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = -0.1f;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject newFielder = Instantiate(fielderPrefab, worldPos, Quaternion.identity);

            // Flip scale based on position relative to batter
            Vector3 scale = newFielder.transform.localScale;
            if (newFielder.transform.position.x < batter.position.x)
            {
                scale.x = Mathf.Abs(scale.x); // face right
            }
            else
            {
                scale.x = -Mathf.Abs(scale.x); // face left
            }
            newFielder.transform.localScale = scale;

            SpawnedFielders.Add(newFielder);
            fieldersPlaced++;
            fieldersLeft--;
        }
    }
    
    //void PlaceFielder(FielZone zone)
    //{
    //    GameObject fielder = Instantiate(fielderPrefab, zone.transform.position, Quaternion.identity);
    //    zone.isOccupied = true;
    //    fieldersPlaced++;
    //}
}
