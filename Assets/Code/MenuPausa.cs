using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    private bool JuegoPausado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }

    public void Reanudar()
    {
        JuegoPausado = false;
        Time .timeScale = 1f;
        menuPausa.SetActive(false);
    }
}
