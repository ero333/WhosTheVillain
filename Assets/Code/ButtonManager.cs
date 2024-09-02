using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonHeld = false;

    // Este m�todo se llama cuando el bot�n es presionado
    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    // Este m�todo se llama cuando el bot�n es soltado
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isButtonHeld)
        {
            Destroy(gameObject);
        }
        isButtonHeld = false;
    }
}