using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    public GameObject[] uiElementsToIgnore;  // Lista de elementos de UI para ignorar

    void Update()
    {
        // Detecta si el clic izquierdo del ratón está presionado
        bool Sabotaje = Input.GetMouseButton(0) && !IsPointerOverIgnoredUI();

        // Actualiza el parámetro en el Animator
        animator.SetBool("Sabotaje", Sabotaje);
    }

    // Método para verificar si el mouse está sobre alguno de los elementos en uiElementsToIgnore
    private bool IsPointerOverIgnoredUI()
    {
        // Crear una lista de resultados de raycast
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> raycastResults = new List<RaycastResult>();

        // Realizar el raycast
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        // Verificar si alguno de los elementos ignorados está en los resultados del raycast
        foreach (RaycastResult result in raycastResults)
        {
            foreach (GameObject uiElement in uiElementsToIgnore)
            {
                if (result.gameObject == uiElement)
                {
                    return true;  // Si está sobre uno de los elementos ignorados, retorna true
                }
            }
        }

        return false;  // Si no está sobre ninguno de los elementos ignorados, retorna false
    }
}
