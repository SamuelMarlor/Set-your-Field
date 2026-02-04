using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class WicketPlacement : MonoBehaviour
{
    public Camera cam;
    public int maxFielders = 9;
    public int F = 9;


    public int fieldersPlaced = 0;
    private List<GameObject> SpawnedFielders = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryPlaceFielder();
        }

        
    }

    

    void TryPlaceFielder()
    {
        // Global limit
        if (F >= maxFielders)
            return;


    }
}