using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance { get; private set; }
    private int timeElapsed = 0;
    private bool isCounting = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    async void Start()
    {
        await UnityServices.InitializeAsync();

        AnalyticsService.Instance.StartDataCollection();
        Debug.Log("Se inicia la recopilaci�n de datos.");
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeManager()
    {
        if (Instance == null)
        {
            GameObject analyticsManager = new GameObject("AnalyticsManager");
            analyticsManager.AddComponent<AnalyticsManager>();
        }
    }

    // M�todo para iniciar el conteo de tiempo
    public void StartCounting()
    {
        timeElapsed = 0;
        isCounting = true;
        StartCoroutine(CountTime());
    }

    // M�todo para detener el conteo de tiempo
    public void StopCounting()
    {
        isCounting = false;
    }

    // M�todo para obtener el tiempo transcurrido
    public int GetTimeElapsed()
    {
        return timeElapsed;
    }

    // Coroutine para contar el tiempo en segundos
    private IEnumerator CountTime()
    {
        while (isCounting)
        {
            yield return new WaitForSeconds(1);
            timeElapsed++;
        }
    }
    public void ResetTime()
    {
        timeElapsed = 0;  // Reinicia el tiempo transcurrido
        isCounting = true; // Aseg�rate de que comience a contar nuevamente
    }
}
