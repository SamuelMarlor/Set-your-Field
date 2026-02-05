using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class OuterRing : MonoBehaviour
{
    public Camera cam;
    public GameObject fielderPrefab;
    public int maxFielders = 9;
    public int fieldersLeft = 9;
    public Transform batter;
    public TMP_Text fieldersRemainingText;
    public FielderPlacementManager manager; // reference to global manager
    public int FieldersOuterRing = 0;
    public int FieldersOuterMax = 4;

    private int fieldersPlaced = 0;
    private List<GameObject> SpawnedFielders = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceFielder();
        }

        fieldersRemainingText.text = fieldersLeft.ToString();
    }

    void TryPlaceFielder()
    {
        if (fieldersPlaced >= maxFielders)
            return;

        if (FieldersOuterRing >= FieldersOuterMax)
            return;

        if (manager.fieldersLeft <= 0)
            return;

        Vector3 worldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0f;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name + " | Tag: " + hit.collider.tag);
        }
        else
        {
            Debug.Log("No collider hit");
            return;
        }

        if (!hit.collider.CompareTag("OuterRing"))
            return;

        GameObject newFielder = Instantiate(fielderPrefab, worldPos, Quaternion.identity);

        Vector3 scale = newFielder.transform.localScale;
        if (newFielder.transform.position.x < batter.position.x)
            scale.x = Mathf.Abs(scale.x);
        else
            scale.x = -Mathf.Abs(scale.x);

        newFielder.transform.localScale = scale;

        SpawnedFielders.Add(newFielder);
        fieldersPlaced++;
        FieldersOuterRing++;
        fieldersLeft--;

        manager.RegisterPlacement();

    }
}




