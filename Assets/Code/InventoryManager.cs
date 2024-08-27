using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public Image[] inventorySlots;
    bool lleno = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

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
        print(item.name);
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].sprite == null)
            {
                inventorySlots[i].sprite = item.itemIcon;
                inventorySlots[i].preserveAspect = true;
                //inventorySlots[i].GetComponent<Button>().interactable = false;
                
                break;
                

            }
        }

    }
    void Update()
    {
        // código para q si están las 5 pistas se muestre un botón para ir al informe//

      

    }
}
