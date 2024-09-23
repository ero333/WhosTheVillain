using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarDatos : MonoBehaviour
{
    public static GuardarDatos Instancia;
    public int NivelesDesbloqueados;
    // Start is called before the first frame update

    private void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        NivelesDesbloqueados = PlayerPrefs.GetInt("Niveles Ganados", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GuardarProgreso(int NW)
    {
        if (NW >= NivelesDesbloqueados)
        {
            PlayerPrefs.SetInt("Niveles Ganados", NW);
            print(NW + "niveles guardados");
        }
    }

    public void BorrarProgreso()
    {
        PlayerPrefs.DeleteAll();
    }
}
