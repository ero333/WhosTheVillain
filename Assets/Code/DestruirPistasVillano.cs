using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirPistasVillano : MonoBehaviour
{
    public static int objectsDestroyed = 0;
    public int totalObjects = 5;
    public GameObject button;
    public Text objectCounterText;

    // Start is called before the first frame update
    void Start()
    {
        objectsDestroyed = 0;
        button.SetActive(false);
        UpdateObjectCounterText();
    }

    void OnDestroy()
    {
        objectsDestroyed++;
        UpdateObjectCounterText();
        if (objectsDestroyed >= totalObjects)
        {
            button.SetActive(true);
        }
    }

    void UpdateObjectCounterText()
    {
        if (objectCounterText != null)
        {
          objectCounterText.text = objectsDestroyed + "/" + totalObjects;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
