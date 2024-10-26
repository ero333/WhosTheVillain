using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarDatos : MonoBehaviour
{
    public static GuardarDatos Instancia;
    public int NivelesDesbloqueados;
    public Scene NivelActual;
    private Dictionary<int, string> levelScenes = new Dictionary<int, string>();

    private void Awake()
    {
        Instancia = this;
        InitializeLevelScenes();

        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1); // Iniciar desde el primer nivel
        }
    }

    void Start()
    {
        DetectarNivelActual();
        NivelesDesbloqueados = PlayerPrefs.GetInt("Niveles Ganados", 0);
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

    public void DetectarNivelActual()
    {
        NivelActual = SceneManager.GetActiveScene();
        int x = NivelActual.buildIndex;

        if (!levelScenes.ContainsKey(x))
        {
            PlayerPrefs.SetInt("UltimoNivel", x);
        }
    }

    public void ContinuarPartida()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        if (currentLevel <= NivelesDesbloqueados)
        {
            if (levelScenes.ContainsKey(currentLevel + 1))
            {
                SceneManager.LoadScene(levelScenes[currentLevel + 1]);
            }
            else
            {
                Debug.LogError("No hay una escena configurada para el siguiente nivel.");
            }
        }
        else
        {
            Debug.LogError("No hay un nivel desbloqueado siguiente.");
        }
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
