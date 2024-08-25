using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public Image[] invetorySlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        print(item.name);
        for (int i = 0; i < invetorySlots.Length; i++)
        {
            if (invetorySlots[i].sprite == null)
            {
                invetorySlots[i].sprite = item.itemIcon;
                invetorySlots[i].preserveAspect = true;
                invetorySlots[i].GetComponent<Button>().interactable = false;
                break;
            }
        }
    }
}
