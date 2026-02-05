using UnityEngine;

public class FielZoneOuterRing : MonoBehaviour
{
    public bool isOccupied = false;
    public SpriteRenderer highlight;
    public OuterRing outer;

    private bool mouseInside = false;

    void Update()
    {
        // If mouse is inside, update highlight every frame
        if (mouseInside)
        {
            Highlight();
        }
    }

    public void Highlight()
    {
        if (highlight == null || outer == null)
            return;

        // Turn RED when 4 fielders are placed
        if (outer.FieldersOuterRing >= 4)
        {
            highlight.color = new Color(1f, 0f, 0f, 0.4f);   // RED
        }
        else
        {
            highlight.color = new Color(0f, 0f, 1f, 0.4f);   // BLUE
        }
    }

    public void Unhighlight()
    {
        if (highlight != null)
        {
            highlight.color = new Color(1f, 1f, 1f, 0f); // transparent
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

