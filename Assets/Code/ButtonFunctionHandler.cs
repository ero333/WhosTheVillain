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
        // Asigna el m�todo para el evento onValueChanged del Dropdown
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // Inicializa el bot�n con la funci�n predeterminada
        SetButtonFunction();
    }

    void OnDropdownValueChanged(int index)
    {
        // Actualiza la acci�n del bot�n seg�n la opci�n seleccionada en el Dropdown
        SetButtonFunction();
    }

    void SetButtonFunction()
    {
        // Desasocia cualquier funci�n previamente asignada al bot�n
        myButton.onClick.RemoveAllListeners();

        // Asigna una nueva funci�n al bot�n seg�n la opci�n seleccionada
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

        // A�ade la funci�n al bot�n
        myButton.onClick.AddListener(() => currentButtonAction?.Invoke());
    }

    void ActionForOption1()
    {
        Debug.Log("Funci�n para la opci�n 1 ejecutada.");
    }

    void ActionForOption2()
    {
        Debug.Log("Funci�n para la opci�n 2 ejecutada.");
    }

    void ActionForOption3()
    {
        Debug.Log("Funci�n para la opci�n 3 ejecutada.");
    }

    void DefaultAction()
    {
        Debug.Log("Funci�n predeterminada ejecutada.");
    }
}
