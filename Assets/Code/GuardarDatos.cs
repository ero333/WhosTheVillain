using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarDatos : MonoBehaviour
{
    public static GuardarDatos Instancia;
    public int NivelesDesbloqueados;
    public Scene NivelActual;

    // Diccionario para mapear niveles a sus respectivas escenas en ambas campañas
    private Dictionary<int, string> levelScenes = new Dictionary<int, string>();

    private void Awake()
    {
        Instancia = this;
        // Inicializar el mapeo de niveles a escenas
        InitializeLevelScenes();

        // Asegurarse de inicializar el progreso si es la primera vez
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1); // Iniciar desde el primer nivel
        }
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
            print(NW + " niveles guardados");
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
            case 0: break;
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

    private void InitializeLevelScenes()
    {
        levelScenes.Add(1, "Cutscene Intro Detective");
        levelScenes.Add(2, "Cutscene intro villano");
        levelScenes.Add(3, "Cutscene Intro Detective N2");
        levelScenes.Add(4, "Cutscene intro villano2");
        levelScenes.Add(5, "Cutscene Intro Detective 3");
    }

    public void LoadNextCase()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        // Asegúrate de que el siguiente nivel esté disponible
        if (levelScenes.ContainsKey(currentLevel + 1))
        {
            // Aquí deberías verificar que el nivel siguiente esté desbloqueado
            if (currentLevel + 1 <= NivelesDesbloqueados + 1) // +1 porque los niveles empiezan desde 1
            {
                currentLevel++;
                PlayerPrefs.SetInt("CurrentLevel", currentLevel);
                string nextLevelSceneName = levelScenes[currentLevel];
                Debug.Log("Cargando siguiente caso: " + nextLevelSceneName);

                // Cargar el siguiente nivel
                SceneManager.LoadScene(nextLevelSceneName);
            }
            else
            {
                Debug.LogError("No hay un nivel desbloqueado siguiente.");
            }
        }
        else
        {
            Debug.LogError("No hay una escena configurada para el siguiente nivel.");
        }
    }
}
