using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public bool isOccupied = false;

    public Material defaultMaterial;
    public Material highlightMaterial;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
    }

    void OnMouseEnter()
    {
        if (!isOccupied)
        {
            rend.material = highlightMaterial;
        }
    }

    void OnMouseExit()
    {
        if (!isOccupied)
        {
            rend.material = defaultMaterial;
        }
    }
}
