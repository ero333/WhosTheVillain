using UnityEngine;
using UnityEngine.Events;

public class ObjetoBarra : MonoBehaviour
{
    public BarraVillano barravillano;
    public UnityEvent OnHold;
    public bool isHolding;
    public bool isTrue = false;

    private void OnMouseDown()
    {
        if (barravillano != null)
        {
            // Verifica si el objeto actual es diferente antes de iniciar el llenado
            barravillano.StartFilling(this.gameObject);
            isHolding = true;
        }
    }

    private void OnMouseUp()
    {
        if (barravillano != null)
        {
            barravillano.StopFilling();
            isHolding = false;
        }
    }
}