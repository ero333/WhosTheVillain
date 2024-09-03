using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVillano : MonoBehaviour
{
    public Image progressBar;
    public float fillSpeed = 0.5f;
    public bool isFilling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFilling)
        {
            progressBar.fillAmount += fillSpeed * Time.deltaTime;
            if (progressBar.fillAmount >= 1 ) 
            {
                progressBar.fillAmount = 0;
                isFilling = false;
                //Destroy(gameObject);
            }
        }
       
    }

    public void StartFilling()
    {
        isFilling = true;

    }

    public void StopFilling()
    { 
        isFilling = false; 
    }
}
