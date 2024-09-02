using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonHeld = false;

    // Este método se llama cuando el botón es presionado
    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    // Este método se llama cuando el botón es soltado
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isButtonHeld)
        {
            Destroy(gameObject);
        }
        isButtonHeld = false;
    }
}