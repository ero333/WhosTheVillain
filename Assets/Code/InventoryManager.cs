using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public Image[] inventorySlots;
    public Button changeSceneButton; // Referencia al botón de cambio de escena
    private bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        if (changeSceneButton != null)
        {
            changeSceneButton.gameObject.SetActive(false); // Asegurarse de que esté oculto al principio
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(InventoryItem item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].sprite == null)
            {
                inventorySlots[i].sprite = item.itemIcon;
                inventorySlots[i].preserveAspect = true;
                CheckInventoryFull(); // Comprobar si el inventario está lleno
                break;
            }
        }
    }

    private void CheckInventoryFull()
    {
        isFull = true;
        foreach (Image slot in inventorySlots)
        {
            if (slot.sprite == null)
            {
                isFull = false;
                break;
            }
        }

        if (isFull && changeSceneButton != null)
        {
            changeSceneButton.gameObject.SetActive(true); // Mostrar el botón cuando el inventario esté lleno
        }
    }
}

