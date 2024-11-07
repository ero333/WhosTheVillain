using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public string levelName;
    public string initialSceneName;
    public bool isInitialScene;
    public string numberLevel;
    Scene nivelActual;
    public string section;

    public int level;
    public int Nivel;

    // Start is called before the first frame update
    void Start()
    {
        nivelActual = SceneManager.GetActiveScene();

        if (GameManager.instance == null)
        {
            // Crear el GameManager si no existe
            GameObject gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager>();
            Debug.Log("GameManager creado en la escena: " + SceneManager.GetActiveScene().name);
        }

        if (isInitialScene && !string.IsNullOrEmpty(initialSceneName))
        {
            Debug.Log("Configurando escena inicial: " + initialSceneName + " para el nivel: " + levelName);
            GameManager.instance.SetInitialScene(levelName, initialSceneName);
        }

        switch (SceneManager.GetActiveScene().name)
        {
            case "Cutscene Intro Detective":
                level = 1;
                break;
            case "Cutscene intro villano":
                level = 2;
                break;
            case "Cutscene Intro Detective N2":
                level = 3;
                break;
            case "Cutscene intro villano2":
                level = 4;
                break;
            case "Cutscene Intro Detective 3":
                level = 5;
                break;
            case "Cutscene Intro Villano 3":
                level = 6;
                break;
            default:
                level = 0;
                break;
        }

        if (level != 0)
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
            Debug.Log("level: " + level);

            // Crear y enviar el evento LevelStart
            CustomEvent levelStartEvent = new CustomEvent("LevelStart")
            {
                { "level", level }
            };
            AnalyticsService.Instance.RecordEvent(levelStartEvent);

            AnalyticsService.Instance.Flush();

            AnalyticsManager.Instance.StartCounting();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarEscena(int a)
    {
        StartCoroutine(LoadSceneAndCleanUp(a));
    }

    public void EventoSkip(int a)
    {
        StartCoroutine(LoadSceneAndCleanUp(a));
        //Debug.Log("Skip");
    }

    public void SiguienteNivel()
    {
        StartCoroutine(LoadSceneAndCleanUp(nivelActual.buildIndex + 1));
    }

    public void Menu()
    {
        StartCoroutine(LoadSceneAndCleanUp("MenuPrincipal"));
    }

    public void Selector()
    {
        StartCoroutine(LoadSceneAndCleanUp("Selector de niveles"));
    }

    public void DNivel1()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 1 Oficina"));
    }

    public void DNivel2()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 2 Oficina D"));
    }

    public void DNivel3()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 3 Oficina D"));
    }

    public void CineV1()
    {
        StartCoroutine(LoadSceneAndCleanUp("Cutscene intro villano"));
    }

    public void VNivel1()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 1 villano"));
    }

    public void CineV2()
    {
        StartCoroutine(LoadSceneAndCleanUp("Cutscene intro villano2"));
    }

    public void VNivel2()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 2 villano"));
    }

    public void VNivel3()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 3 villano"));
    }

    public void LogrosDetective()
    {
        StartCoroutine(LoadSceneAndCleanUp("Logros Detective"));
    }

    public void LogrosVillano()
    {
        StartCoroutine(LoadSceneAndCleanUp("Logros Villano"));
    }

    public void PantallaDerrotaVillano()
    {
        StartCoroutine(LoadSceneAndCleanUp("Pantalla Derrota Villano"));
    }

    public void VNivel1pt2()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 1 Villano pt2"));
    }

    public void VNivel1Interrogatorio()
    {
        StartCoroutine(LoadSceneAndCleanUp("Nivel 1 Villano Interrogatorio"));
    }

    public void PantallaDerrotaDetective()
    {
        StartCoroutine(LoadSceneAndCleanUp("Pantalla Derrota"));
    }

    public void PantallaVictoriaDetective()
    {
        StartCoroutine(LoadSceneAndCleanUp("Pantalla Victoria"));
    }

    public void CutsceneDerrotaDetective()
    {
        StartCoroutine(LoadSceneAndCleanUp("Cutscene Derrota D"));
    }

    public void C1D()
    {
        StartCoroutine(LoadSceneAndCleanUp("Cutscene Intro Detective"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SiguienteNivel();
    }

    private IEnumerator LoadSceneAndCleanUp(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Liberar la escena anterior
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private IEnumerator LoadSceneAndCleanUp(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Liberar la escena anterior
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}