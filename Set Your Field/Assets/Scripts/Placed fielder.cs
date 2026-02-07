using UnityEngine;

public class PlacedFielder : MonoBehaviour
{
    public FielderPlacementManager manager;
    public OuterRing outerRing;
    public static bool clickedFielder = false;
    public bool isInnerRing = false;
    public bool isOuterRing = false;

    private void OnMouseDown()
    {
        // Stop the click from passing through to the OuterRing
        GetComponent<Collider2D>().enabled = true;

        // Update manager counts
        manager.fieldersPlaced--;
        manager.fieldersLeft++;
        manager.fieldersRemainingText.text = manager.fieldersLeft.ToString();

        // Update outer ring count
        // Update correct ring
        if (isOuterRing && outerRing != null)
            outerRing.FieldersOuterRing--;

        if (isInnerRing)
            manager.fieldersLeft++;    // use your actual inner ring counter variable;

        // Destroy next frame so the click cannot hit the OuterRing
        Destroy(gameObject, 0.01f);
    }
}
