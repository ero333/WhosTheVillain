using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoBarra : MonoBehaviour
{
    public BarraVillano barravillano;

    // Start is called before the first frame update
    void Start()
    {
        
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

        }
    }

    private void OnMouseUp()
    {
        if(barravillano != null)
        {
            barravillano.StopFilling();
        }
    }
}
