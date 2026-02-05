using UnityEngine;



public class Wicket : MonoBehaviour
{
    public bool isOccupied = false;
    public int F = 9;
    public SpriteRenderer highlight;
    public FielderPlacementManager inner;   // reference to global manager

    private bool mouseInside = false;

   

    public void Highlight()
    {
        if (highlight == null || inner == null)
            return;


        if (F >= inner.maxFielders)
        {
            highlight.color = new Color(1f, 0f, 0f, 0.4f);   // RED
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
