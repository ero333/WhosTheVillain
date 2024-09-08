using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class EnemigoVillano : MonoBehaviour
{
    public float Aparicion;
    public float Vigilar;
    public float cronometro;
    public Animator anim;
    public bool Entrada;
    public bool Salida;

    public GameObject[] Pistas;

    public bool isHolding = false;

    public Button botonCambioEscena;
    public int cantidadObjetos = 5;
    public int objetosDestruidos = 0;
    //public string PantallaDerrotaVillano;

    // Start is called before the first frame update
    void Start()
    {
        Entrada = true;
        cronometro = Vigilar;
        isHolding = false;

        if (botonCambioEscena != null )
        {
            botonCambioEscena.gameObject.SetActive(false);
        }
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

        isHolding = false;
        List<GameObject> pistasValidas = new List<GameObject>();

        foreach (GameObject pista in Pistas)
        {
            if (pista != null)
            {
                pistasValidas.Add(pista);

                if (pista.GetComponent<Collider2D>() != null && Input.GetMouseButton(0))
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (pista.GetComponent<Collider2D>().OverlapPoint(mousePos))
                    {
                        ObjetoBarra script = pista.GetComponent<ObjetoBarra>();
                        if (script != null)
                        {
                            Debug.Log(pista.name + " isTrue " + script.isTrue);
                            if (script.isTrue)
                            {
                                isHolding = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        Pistas = pistasValidas.ToArray();

        if (Entrada && isHolding)
        {
            Debug.Log("Cambiando a la escena Pantalla Derrota Villano");
            SceneManager.LoadScene("Pantalla Derrota Villano");
        }
    }
    public void DestroyPista(GameObject pista)
    {
        List<GameObject> pistaList = new List<GameObject>(Pistas);
        pistaList.Remove(pista);
        Pistas = pistaList.ToArray();

        Destroy(pista);

        objetosDestruidos++;
        Debug.Log("Objetos destruidos: " + objetosDestruidos);

        if (objetosDestruidos >= cantidadObjetos && botonCambioEscena != null)
        {
            Debug.Log("Activando botón de cambio de escena");
            botonCambioEscena.gameObject.SetActive(true);
        }
    }

}
