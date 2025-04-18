using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public GameObject tooltipPanel;
    public Text tooltipText;

    private void Start()
    {
        tooltipPanel.SetActive(false);  // Inicialmente el tooltip está desactivado
    }

    public void ShowTooltip(string text)
    {
        tooltipText.text = text;
        tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }

    private void OnMouseEnter()
    {
        // Aquí activamos el tooltip solo cuando el mouse entra en el slot
        tooltipPanel.SetActive(true);

        // Aquí obtenemos el texto que debe mostrar el tooltip
        string itemName = "Nombre del Objeto"; // Usa el nombre del objeto que le pongas
        tooltipText.text = itemName;
    }

    private void OnMouseExit()
    {
        // Desactivamos el tooltip solo cuando el mouse sale del slot
        tooltipPanel.SetActive(false);
    }

    private void Update()
    {

    }
}
