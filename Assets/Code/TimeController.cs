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

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
        pistasVillano = FindObjectOfType<DestruirPistasVillano>();
        tiempoTranscurrido = 0f;
    }

    void Start()
    {
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
                Debug.Log("Pistas no destruidas: " + pistasNoDestruidas);
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
        Time.timeScale = 0;

        if (gameOverPorTiempo)
        {
            RegistrarEventoGameOver(true);
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

        Unity.Services.Analytics.CustomEvent gameOverEvent = new Unity.Services.Analytics.CustomEvent("GameOverVillano")
    {
        { "level", nivelActual },
        { "time", tiempoTotal },
        { "timeout", timeout },
        { "section", currentSection },
    };

        AnalyticsService.Instance.RecordEvent(gameOverEvent);
        Debug.Log("GameOver: tiempo " + tiempoTotal + ", timeout: " + timeout + ", level: " + nivelActual + ", section: " + currentSection);

        gameOverRegistered = true; // Marca el Game Over como registrado

        // Cambiar a la escena de derrota, solo si realmente ha habido un Game Over
        if (timeout)
        {
            SceneManager.LoadScene("Pantalla Derrota");
        }
    }
}