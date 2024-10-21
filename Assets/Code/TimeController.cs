using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    private bool enMarcha;
    private DestruirPistasVillano pistasVillano;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
        pistasVillano = FindObjectOfType<DestruirPistasVillano>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                enMarcha = false;
                int pistasNoDestruidas = pistasVillano.totalObjects - DestruirPistasVillano.objectsDestroyed;
                Debug.Log("Pistas no destruidas: " + pistasNoDestruidas);
                SceneManager.LoadScene("Pantalla Derrota Villano");
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int TempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, TempSeg);
        }
    }

    public void DetenerTiempo()
    {
        enMarcha = false;
    }
}