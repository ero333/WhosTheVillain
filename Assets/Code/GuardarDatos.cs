using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarDatos : MonoBehaviour
{
    public static GuardarDatos Instancia;
    public int NivelesDesbloqueados;
    public Scene NivelActual;

    // Start is called before the first frame update

    private void Awake()
    {
        Instancia = this;
    }

    void Start()
    {
        DetecterNivelActual();
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

    public void DetecterNivelActual()
    {
        NivelActual = SceneManager.GetActiveScene();
        int x = NivelActual.buildIndex;
        switch (x)
        {
            case 0:
                break;
            case 5: break;
            case 6: break;
            case 7: break;
            case 9: break;
            case 10: break;
            case 13: break;
            case 14: break;
            case 15: break;
            case 16: break;
            case 24: break;
            case 25: break;
            case 26: break;
            case 27: break;
            case 28: break;
            case 29: break;
            case 30: break;
            case 31: break;
            case 34: break;
            case 37: break;
            case 38: break;
            case 39: break;
            case 40: break;
            default: PlayerPrefs.SetInt("UltimoNivel", x); break;
        }
    }

    public void ContinuarPartida()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("UltimoNivel"));
    }
}