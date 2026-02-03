using UnityEngine;

public class FielZone : MonoBehaviour 
{
    public bool isOccupied = false;
    public SpriteRenderer highlight;

    public void Highlight()
    {
         if(highlight != null)
        {
            highlight.color = new Color(1f, 1f, 0f, 0.4f);
        }
    }

    public void Unhighlight()
    {
        if (highlight != null)
        {
            highlight.color = new Color(1f, 1f, 0f, 0f);
        }
    }

  private void OnMouseEnter()
{
    Debug.Log("Mouse entered " + gameObject.name);
    Highlight();
}

    private void OnMouseExit()
    {
        Unhighlight();
    }
}
