using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public Image[] inventorySlots;
    public string[] inventoryName;
    public string[] inventoryDescrip;
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
                inventoryName[i] = item.name;
                inventoryDescrip[i] = item.itemDescrip;
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

    public GameObject Info;
    public Image fotoPista;
    public TMP_Text namePista;
    public TMP_Text descriptionPista;
    public void abrirInfo(int pista)
    {
        Info.SetActive(true);
        fotoPista.sprite = inventorySlots[pista].sprite;
   
        namePista.text = inventoryName[pista];
        descriptionPista.text = inventoryDescrip[pista];

    }

}

