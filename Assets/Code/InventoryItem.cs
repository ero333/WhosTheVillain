using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public Sprite itemIcon;
    private static int contador;
    public Button botoninforme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  

    private void OnMouseDown()
    {
        print(itemName);
        InventoryManager.Instance.AddItem(this);
        Destroy(gameObject);
        
        
    }

    void OnDestroy()
    {
        contador++;
        Debug.Log("Objeto destruido.Contador:" + contador);
    }


    private void Update()
    {
        if (contador == 5)
        {
            botoninforme.enabled = true;

        }
        else
        {
            botoninforme.enabled = false;
        }
    }

}
