using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject Enemigo;
    private bool JuegoPausado = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        JuegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        if (Enemigo != null)
        {
            Enemigo.GetComponent<EnemigoVillano>().enabled = false; // Desactivar el script del enemigo
        }
    }

    public void Reanudar()
    {
        JuegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        if (Enemigo != null)
        {
            Enemigo.GetComponent<EnemigoVillano>().enabled = true; // Reactivar el script del enemigo
        }
    }
}

