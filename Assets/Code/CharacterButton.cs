using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string characterDescription;
    public Text descriptionText;
    public Image descriptionBackground; // Agregar un fondo para el texto
    private Button button;

    void Start()
    {
        descriptionText.enabled = false;
        descriptionBackground.enabled = false; // Desactivar el fondo al inicio
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Pointer entered on " + gameObject.name);
        descriptionText.text = characterDescription;
        descriptionText.enabled = true;
        descriptionBackground.enabled = true; // Activar el fondo
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Pointer exited from " + gameObject.name);
        descriptionText.enabled = false;
        descriptionBackground.enabled = false; // Desactivar el fondo
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Pointer clicked on " + gameObject.name);
        descriptionText.enabled = false;
        descriptionBackground.enabled = false; // Desactivar el fondo
        button.interactable = false; // Deshabilitar el botón para que no se pueda hacer click otra vez
    }
}
