using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        InicializarEstado();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0)
        {
            return;
        }

        cronometro -= Time.deltaTime;

        // Check if the enemy is in the entrance, exit, or vigilance animation
        bool isInEntranceAnimation = anim.GetCurrentAnimatorStateInfo(0).IsName("EnemigoEntrada");
        bool isInExitAnimation = anim.GetCurrentAnimatorStateInfo(0).IsName("EnemigoSalida");
        bool isInVigilanceAnimation = anim.GetCurrentAnimatorStateInfo(0).IsName("EnemigoObserva");

        if (cronometro <= 0 && Entrada)
        {
            Entrada = false;
            Salida = true;
            Aparicion = Random.Range(AparicionMin, AparicionMax);
            cronometro = Aparicion;
            anim.SetBool("EnemigoSeVa", true);
        }
        else if (cronometro <= 0 && Salida)
        {
            Entrada = true;
            Salida = false;
            Vigilar = Random.Range(VigilarMin, VigilarMax);
            cronometro = Vigilar;
            anim.SetBool("EnemigoSeVa", false);
            RestablecerPistas();
        }

        // Solo comprobar clics si estamos en la animación de vigilancia
        if (isInVigilanceAnimation)
        {
            ComprobarClics();
        }

        if (Entrada && isHolding)
        {
            Debug.Log("Cambiando a la escena CutsceneDerrotaVillano B");
            SceneManager.LoadScene("CutsceneDerrotaVillano B");
        }
    }

    private void InicializarEstado()
    {
        Entrada = true;
        Aparicion = Random.Range(AparicionMin, AparicionMax);
        Vigilar = Random.Range(VigilarMin, VigilarMax);
        cronometro = Vigilar;
        isHolding = false;
        RestablecerPistas();
    }

    private void RestablecerPistas()
    {
        List<GameObject> pistasValidas = new List<GameObject>();

        foreach (GameObject pista in Pistas)
        {
            if (pista != null)
            {
                pistasValidas.Add(pista);
            }
        }

        Pistas = pistasValidas.ToArray();
    }

    private void ComprobarClics()
    {
        isHolding = false;

        foreach (GameObject pista in Pistas)
        {
            if (pista != null)
            {
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


