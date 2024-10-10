using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesbloqueoDeNiveles : MonoBehaviour
{
    public int NivelesDesbloqueados;
    public Button[] BotonesNiveles;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button Boton in BotonesNiveles)
        {
            Boton.interactable = false;
        }
        NivelesDesbloqueados = PlayerPrefs.GetInt("Niveles Ganados");
        for (int i = 0; i <= NivelesDesbloqueados; i++)
        {
            BotonesNiveles[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            DesbloquearTodosLosNiveles();
        }
    }

    void DesbloquearTodosLosNiveles()
    {
        foreach (Button Boton in BotonesNiveles)
        {
            Boton.interactable = true;
        }
        PlayerPrefs.SetInt("Niveles Ganados", BotonesNiveles.Length - 1);
        PlayerPrefs.Save();
    }
}