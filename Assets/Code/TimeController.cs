using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    private bool enMarcha;
    private DestruirPistasVillano pistasVillano;
    private float tiempoTranscurrido;

    private bool hasLostLevel = false;

    private AnalyticsManager analyticsManager;
    public int timeTranscurrido;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
        pistasVillano = FindObjectOfType<DestruirPistasVillano>();
        tiempoTranscurrido = 0f;
    }

    void Start()
    {
        analyticsManager = FindObjectOfType<AnalyticsManager>();
        hasLostLevel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            tiempoTranscurrido += Time.deltaTime;

            if (restante < 1)
            {
                enMarcha = false;
                int pistasNoDestruidas = pistasVillano.totalObjects - DestruirPistasVillano.objectsDestroyed;
                //Debug.Log("Pistas no destruidas: " + pistasNoDestruidas);

                RegistrarEventoMissingClue();

                RegistrarEventoGameOver(true);
                SceneManager.LoadScene("Pantalla Derrota Villano");
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int TempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, TempSeg);
        }
    }

    public void DetenerTiempo(bool gameOverPorTiempo)
    {
        enMarcha = false; // Detiene la cuenta regresiva sin pausar el juego completo

        if (gameOverPorTiempo)
        {
            RegistrarEventoGameOver(true); // Solo registra Game Over si fue por quedarse sin tiempo
        }
    }

    private bool gameOverRegistered = false;

    private void RegistrarEventoGameOver(bool timeout)
    {
        if (gameOverRegistered) return; // Evita registrar más de una vez

        int tiempoTotal = Mathf.FloorToInt(tiempoTranscurrido);
        CambioEscenas cambioEscenas = FindObjectOfType<CambioEscenas>();
        string currentSection = cambioEscenas.section;
        int nivelActual = cambioEscenas.Nivel;
        hasLostLevel = true;

        analyticsManager.StopCounting();
        int timeTranscurrido = analyticsManager.GetTimeElapsed();

        Unity.Services.Analytics.CustomEvent gameOverEvent = new Unity.Services.Analytics.CustomEvent("GameOver")
    {
        { "level", nivelActual },
        { "time", tiempoTotal },
        { "timeout", timeout },
        { "section", currentSection },
        { "time", timeTranscurrido}
    };

        AnalyticsService.Instance.RecordEvent(gameOverEvent);
        Debug.Log("GameOver: tiempo " + tiempoTotal + ", timeout: " + timeout + ", level: " + nivelActual + ", section: " + currentSection + ", time:" + timeTranscurrido);

        gameOverRegistered = true; // Marca el Game Over como registrado

        // Cambiar a la escena de derrota, solo si realmente ha habido un Game Over
        if (timeout)
        {
            SceneManager.LoadScene("Pantalla Derrota");
        }
    }

    private void RegistrarEventoMissingClue()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        List<string> cluesMissing = new List<string>();

        // Obtener todas las pistas en la escena
        DestruirPistasVillano[] pistas = FindObjectsOfType<DestruirPistasVillano>();

        // Recoger las pistas que no se destruyeron
        foreach (DestruirPistasVillano pista in pistas)
        {
            if (pista != null && pista.gameObject.activeInHierarchy) // Si la pista está activa, no se ha destruido
            {
                cluesMissing.Add(pista.clue); // Agregar el nombre de la pista no destruida
            }
        }

        // Enviar un evento por cada pista no destruida
        foreach (string clue in cluesMissing)
        {
            // Crear el evento y registrar los datos para cada pista
            Unity.Services.Analytics.CustomEvent missingClueEvent = new Unity.Services.Analytics.CustomEvent("MissingClue")
        {
            {"levelV", currentLevel},
            {"clue", clue} // Registrar solo la pista específica
        };

            AnalyticsService.Instance.RecordEvent(missingClueEvent);

            // Imprimir en consola el mensaje deseado
            Debug.Log($"MissingClue: levelV: {currentLevel}, clue: \"{clue}\"");
        }
    }
}