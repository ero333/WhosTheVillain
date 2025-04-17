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

    public void AgregarObjeto(Sprite spriteDelObjeto)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].sprite == null)
            {
                slots[i].sprite = spriteDelObjeto;
                slots[i].color = Color.white;
                break;  // Salir del loop después de asignar el sprite al primer slot vacío
            }
        }

        Debug.Log("Objeto agregado al inventario.");
    }
}
