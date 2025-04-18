using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string itemName; // Este se asignará dinámicamente cuando pongas un objeto en el slot
    public ItemTooltip tooltip; // Asignalo desde el inspector

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltip != null && !string.IsNullOrEmpty(itemName))
        {
            tooltip.ShowTooltip(itemName);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (tooltip != null)
        {
            tooltip.HideTooltip();
        }
    }
}
