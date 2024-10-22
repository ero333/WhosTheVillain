using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeElapsed; // Tiempo acumulado
    public Text timerText; // Referencia al componente Text

    void Start()
    {
        timeElapsed = 0f; // Inicializa el contador
    }

    void Update()
    {
        timeElapsed += Time.deltaTime; // Aumenta el tiempo cada frame
        UpdateTimerDisplay(); // Actualiza la visualizaci�n del tiempo
    }

    void UpdateTimerDisplay()
    {
        // Formatea el tiempo a minutos y segundos
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void OnDisable()
    {
        // Llama a Debug.Log al cambiar de escena
        Debug.Log("timeclue: Cambiando de escena. Tiempo transcurrido: " + timeElapsed + " segundos.");
    }
}