using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionHandler : MonoBehaviour
{
    public Dropdown myDropdown;
    public Button myButton;

    void Start()
    {
        // Asigna el método para el evento onValueChanged del Dropdown
        myDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        // Inicializa el botón con la función predeterminada
        SetButtonFunction();
    }

    void OnDropdownValueChanged(int index)
    {
        // Actualiza la función del botón según la opción seleccionada en el Dropdown
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
                myButton.onClick.AddListener(() => LoadScene("Pantalla Derrota")); // Cambia a la escena 3
                break;
            case 1:
                myButton.onClick.AddListener(() => LoadScene("Pantalla Victoria")); // Cambia a la escena 4
                break;
            default:
                myButton.onClick.AddListener(DefaultAction); // Acción predeterminada para otras opciones
                break;
        }
    }

    void DefaultAction()
    {
        Debug.Log("Función predeterminada ejecutada.");
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
