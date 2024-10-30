using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cuestionario : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public string textoDescripcion;
        public string textoPregunta;
        public string[] respuestas;
        public int[] respuestasCorrectas; // Cambiado a un array para múltiples respuestas correctas
    }

    public Pregunta[] preguntas;
    public Text textoDescripcion; //caja de preguntas
    public Text textoPreguntaRespuesta; //caja de respuestas
    public Button botonSiguiente;
    public Button[] botonesRespuestas;
    public GameObject preguntaPanel;
    public GameObject respuestaPanel;

    private int preguntaActual = 0;
    private int respuestasCorrectas = 0;

    public string victoryScene;
    public string defeatScene;

    public int NivelAGuardar;

    void Start()
    {
        MostrarPregunta();
        botonSiguiente.onClick.AddListener(MostrarRespuestas);
    }

    void MostrarPregunta()
    {
        preguntaPanel.SetActive(true);
        respuestaPanel.SetActive(false);
        textoDescripcion.text = preguntas[preguntaActual].textoDescripcion;
    }

    void MostrarRespuestas()
    {
        preguntaPanel.SetActive(false);
        respuestaPanel.SetActive(true);

        textoPreguntaRespuesta.text = preguntas[preguntaActual].textoPregunta;

        for (int i = 0; i < botonesRespuestas.Length; i++)
        {
            botonesRespuestas[i].GetComponentInChildren<Text>().text = preguntas[preguntaActual].respuestas[i];
            botonesRespuestas[i].onClick.RemoveAllListeners();
            int index = i;
            botonesRespuestas[i].onClick.AddListener(() => VerificarRespuesta(index));
        }
    }

    void VerificarRespuesta(int index)
    {
        if (System.Array.Exists(preguntas[preguntaActual].respuestasCorrectas, respuesta => respuesta == index))
        {
            respuestasCorrectas++;
        }

        preguntaActual++;
        if (preguntaActual < preguntas.Length)
        {
            MostrarPregunta();
        }
        else
        {
            EvaluarResultado();
        }
    }

    void EvaluarResultado()
    {
        string victorySceneName = victoryScene;
        string defeatSceneName = defeatScene;

        bool levelCompleted = respuestasCorrectas == preguntas.Length;

        if (levelCompleted)
        {
            GuardarDatos.Instancia.GuardarProgreso(NivelAGuardar);
            PlayerPrefs.SetInt("CurrentLevel", NivelAGuardar);
            PlayerPrefs.Save();

            Unity.Services.Analytics.CustomEvent levelcompleteEvent = new Unity.Services.Analytics.CustomEvent("LevelComplete")
            {
                { "level", NivelAGuardar }
            };
            AnalyticsService.Instance.RecordEvent(levelcompleteEvent);
            Debug.Log("LevelComplete: " + NivelAGuardar);

            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            CambioEscenas cambioEscenas = FindObjectOfType<CambioEscenas>();
            int nivelActual = cambioEscenas.Nivel;
            string currentSection = cambioEscenas.section;

            Unity.Services.Analytics.CustomEvent gameOverEvent = new Unity.Services.Analytics.CustomEvent("GameOver")
            {
                { "level", nivelActual },
                { "section", currentSection }
            };
            AnalyticsService.Instance.RecordEvent(gameOverEvent);
            Debug.Log("GameOver: Level " + nivelActual + ", Section: " + currentSection);

            SceneManager.LoadScene(defeatSceneName);
        }
    }
}
