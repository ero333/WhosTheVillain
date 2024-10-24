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

    private TimeController timeController;

    // Start is called before the first frame update
    void Start()
    {
        objectsDestroyed = 0;
        button.SetActive(false);
        UpdateObjectCounterText();

        timeController = FindObjectOfType<TimeController>();
    }

    void OnDestroy()
    {
        objectsDestroyed++;
        UpdateObjectCounterText();
        if (objectsDestroyed >= totalObjects)
        {
            button.SetActive(true);
            //timeController.DetenerTiempo(false); // False para que no registre como Game Over
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
