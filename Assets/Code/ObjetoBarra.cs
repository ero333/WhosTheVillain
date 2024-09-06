using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjetoBarra : MonoBehaviour
{
    public BarraVillano barravillano;
    public UnityEvent OnHold;
    public bool isHolding;
    public bool isTrue = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name + "isTrue: " + isTrue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (barravillano != null) 
        {
            barravillano.StartFilling(this.gameObject);
            isHolding = true;
        }
    }

    private void OnMouseUp()
    {
        if(barravillano != null)
        {
            barravillano.StopFilling();
            isHolding = false;
        }
    }
}
