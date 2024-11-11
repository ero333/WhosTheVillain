using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;
    public GameObject[] uiElementsToIgnore;  // Lista de elementos de UI para ignorar

    void Update()
    {
        // Detecta si el clic izquierdo del rat�n est� presionado
        bool Sabotaje = Input.GetMouseButton(0) && !IsPointerOverIgnoredUI();

        // Actualiza el par�metro en el Animator
        animator.SetBool("Sabotaje", Sabotaje);
    }

    // M�todo para verificar si el mouse est� sobre alguno de los elementos en uiElementsToIgnore
    private bool IsPointerOverIgnoredUI()
    {
        // Crear una lista de resultados de raycast
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> raycastResults = new List<RaycastResult>();

        // Realizar el raycast
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        // Verificar si alguno de los elementos ignorados est� en los resultados del raycast
        foreach (RaycastResult result in raycastResults)
        {
            foreach (GameObject uiElement in uiElementsToIgnore)
            {
                if (result.gameObject == uiElement)
                {
                    return true;  // Si est� sobre uno de los elementos ignorados, retorna true
                }
            }
        }

        return false;  // Si no est� sobre ninguno de los elementos ignorados, retorna false
    }
}
