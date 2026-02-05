using UnityEngine;



public class FielZone : MonoBehaviour
{
    public bool isOccupied = false;
    public SpriteRenderer highlight;
    public FielderPlacementManager inner;   // reference to global manager

    private bool mouseInside = false;

    void Update()
    {
        // Update highlight live while mouse is inside
        if (mouseInside)
        {
            Highlight();
        }
    }

    public void Highlight()
    {
        if (highlight == null || inner == null)
            return;

        
        if (inner.fieldersPlaced >= inner.maxFielders)
        {
            highlight.color = new Color(1f, 0f, 0f, 0.4f);   // RED
        }
        else
        {
            highlight.color = new Color(1f, 1f, 0f, 0.4f);   // YELLOW
        }
    }

    public void Unhighlight()
    {
        if (highlight != null)
        {
            highlight.color = new Color(1f, 1f, 1f, 0f); // fully transparent
        }
    }

    private void OnMouseEnter()
    {
        mouseInside = true;
        Highlight();
    }

    private void OnMouseExit()
    {
        mouseInside = false;
        Unhighlight();
    }
}
