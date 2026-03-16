using UnityEngine;

public class PlacedFielder : MonoBehaviour
{
    [Header("References")]
    public FielderPlacementManager manager;
    public OuterRing outerRing;

    [Header("Ring Flags")]
    public bool isInnerRing = false;
    public bool isOuterRing = false;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        HandleMouseInput();
        HandleTouchInput();
    }

    // -----------------------------
    // INPUT HANDLING
    // -----------------------------

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectFielder(Input.mousePosition);
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            TrySelectFielder(Input.GetTouch(0).position);
        }
    }

    // -----------------------------
    // RAYCAST CHECK
    // -----------------------------

    private void TrySelectFielder(Vector2 screenPos)
    {
        Vector3 worldPos = cam.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider == null)
            return;

        // Only remove THIS fielder
        if (hit.collider.gameObject != this.gameObject)
            return;

        RemoveFielder();
    }

    // -----------------------------
    // REMOVAL LOGIC
    // -----------------------------

    private void RemoveFielder()
    {
        // Update manager counts
        manager.fieldersPlaced--;
        manager.fieldersLeft++;
        manager.fieldersRemainingText.text = manager.fieldersLeft.ToString();

        // Update outer ring count if needed
        if (isOuterRing && outerRing != null)
        {
            outerRing.FieldersOuterRing--;
        }

        Destroy(gameObject);
    }
}
