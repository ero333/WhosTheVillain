using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ObjetoBarra : MonoBehaviour
{
    public BarraVillano barravillano;
    public UnityEvent OnHold;
    public bool isHolding;
    public bool isTrue = false;
    public Color normalColor;
    public Color highlightedColor;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("ObjetoBarra: No se encontró un componente Image.");
        }
    }

    private void OnMouseEnter()
    {
        if (image != null)
        {
            image.color = highlightedColor;
        }
    }

    private void OnMouseExit()
    {
        if (image != null)
        {
            image.color = normalColor;
        }
    }

    private void OnMouseDown()
    {
        if (barravillano != null)
        {
            // Verifica si el objeto actual es diferente antes de iniciar el llenado
            barravillano.StartFilling(this.gameObject);
            isHolding = true;

            if (image != null)
            {
                image.color = highlightedColor;  // Mantener el color resaltado al hacer clic
            }
        }
    }

    private void OnMouseUp()
    {
        if (barravillano != null)
        {
            barravillano.StopFilling();
            isHolding = false;

            if (image != null)
            {
                image.color = normalColor;  // Revertir al color normal al soltar el clic
            }
        }
    }
}
