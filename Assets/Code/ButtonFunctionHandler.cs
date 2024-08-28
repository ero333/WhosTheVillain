using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonFunctionHandler : MonoBehaviour
{
    public Dropdown myDropdown;
    public Button myButton;

    private Action currentButtonAction;

    void Start()
    {
        // Asigna el método para el evento onValueChanged del Dropdown
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // Inicializa el botón con la función predeterminada
        SetButtonFunction();
    }

    void OnDropdownValueChanged(int index)
    {
        // Actualiza la acción del botón según la opción seleccionada en el Dropdown
        SetButtonFunction();
    }

    void SetButtonFunction()
    {
        // Desasocia cualquier función previamente asignada al botón
        myButton.onClick.RemoveAllListeners();

        // Asigna una nueva función al botón según la opción seleccionada
        switch (myDropdown.value)
        {
            case 0:
                currentButtonAction = ActionForOption1;
                break;
            case 1:
                currentButtonAction = ActionForOption2;
                break;
            case 2:
                currentButtonAction = ActionForOption3;
                break;
            default:
                currentButtonAction = DefaultAction;
                break;
        }

        // Añade la función al botón
        myButton.onClick.AddListener(() => currentButtonAction?.Invoke());
    }

    void ActionForOption1()
    {
        Debug.Log("Función para la opción 1 ejecutada.");
    }

    void ActionForOption2()
    {
        Debug.Log("Función para la opción 2 ejecutada.");
    }

    void ActionForOption3()
    {
        Debug.Log("Función para la opción 3 ejecutada.");
    }

    void DefaultAction()
    {
        Debug.Log("Función predeterminada ejecutada.");
    }
}
