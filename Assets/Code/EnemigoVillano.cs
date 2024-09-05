using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class EnemigoVillano : MonoBehaviour
{
    public float Aparicion;
    public float Vigilar;
    public float cronometro;
    public Animator anim;
    public bool Entrada;
    public bool Salida;
    //public string PantallaDerrotaVillano;

    // Start is called before the first frame update
    void Start()
    {
        Entrada = true;
        cronometro = Vigilar;
    }

    // Update is called once per frame
    void Update()
    {
        cronometro -= Time.deltaTime;
        if (cronometro <= 0 && Entrada)
        {
            Entrada = false;
            Salida = true;
            cronometro = Aparicion;
            anim.SetBool("EnemigoSeVa",true);
        }
        else if (cronometro <= 0 && Salida)
        {
            Entrada = true;
            Salida = false;
            cronometro = Vigilar;
            anim.SetBool("EnemigoSeVa", false);
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(9);
    }
}
