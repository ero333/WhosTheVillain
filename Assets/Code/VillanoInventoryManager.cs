using UnityEngine;
using UnityEngine.UI;

public class VillanoInventoryManager : MonoBehaviour
{
    public static VillanoInventoryManager Instance;

    public Image[] slots; // Asigna estos en el inspector
    public Sprite defaultSlotSprite; // Imagen gris oscura opcional

    private void Awake()
    {
        // Singleton para fácil acceso
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AgregarObjeto(Sprite spriteDelObjeto, string nombreDelObjeto)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].sprite == null)
            {
                slots[i].sprite = spriteDelObjeto;
                slots[i].color = Color.white;

                // Asegurate de que el slot tenga un InventorySlot
                InventorySlot slotComponent = slots[i].GetComponent<InventorySlot>();
                if (slotComponent != null)
                {
                    slotComponent.itemName = nombreDelObjeto;
                }

                break;
            }
        }
    }
}
