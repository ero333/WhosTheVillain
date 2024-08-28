using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionHandler : MonoBehaviour
{
    public Dropdown myDropdown;
    public Button myButton;

    void Start()
    {
        // Asigna el m�todo para el evento onValueChanged del Dropdown
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // Inicializa el bot�n con la funci�n predeterminada
        SetButtonFunction();
    }

    void OnDropdownValueChanged(int index)
    {
        // Actualiza la funci�n del bot�n seg�n la opci�n seleccionada en el Dropdown
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
                myButton.onClick.AddListener(() => LoadScene("Pantalla Derrota")); // Cambia a la escena 3
                break;
            case 1:
                myButton.onClick.AddListener(() => LoadScene("Pantalla Victoria")); // Cambia a la escena 4
                break;
            default:
                myButton.onClick.AddListener(DefaultAction); // Acci�n predeterminada para otras opciones
                break;
        }
    }

    void DefaultAction()
    {
        Debug.Log("Funci�n predeterminada ejecutada.");
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
