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
    public float AparicionMin;
    public float AparicionMax;
    public float VigilarMin;
    public float VigilarMax;
    public float Aparicion;
    public float Vigilar;
    public float cronometro;
    public Animator anim;
    public bool Entrada;
    public bool Salida;

    public GameObject[] Pistas;

    public bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        Entrada = true;
        Aparicion = Random.Range(AparicionMin, AparicionMax);
        Vigilar = Random.Range(VigilarMin, VigilarMax);
        cronometro = Vigilar;
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        cronometro -= Time.deltaTime;
        if (cronometro <= 0 && Entrada)
        {
            Entrada = false;
            Salida = true;
            Aparicion = Random.Range(AparicionMin, AparicionMax);
            cronometro = Aparicion;
            anim.SetBool("EnemigoSeVa",true);
        }
        else if (cronometro <= 0 && Salida)
        {
            Entrada = true;
            Salida = false;
            Vigilar = Random.Range(VigilarMin,VigilarMax);
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
        Debug.Log("DestroyPisya called with: " + pista.name);
        List<GameObject> pistaList = new List<GameObject>(Pistas);
        pistaList.Remove(pista);
        Pistas = pistaList.ToArray();

        Destroy(pista);
    }
}
