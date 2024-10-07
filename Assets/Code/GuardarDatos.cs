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
            default: PlayerPrefs.SetInt("UltimoNivel", x); break;
        }
    }

    public void ContinuarPartida()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("UltimoNivel"));
    }
}