using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cuestionario : MonoBehaviour
{
    [System.Serializable]
    public class Pregunta
    {
        public string textoPregunta;
        public string[] respuestas;
        public int respuestaCorrecta;
    }

    public Pregunta[] preguntas;
    public Text textoPregunta;
    public Button botonSiguiente;
    public Button[] botonesRespuestas;
    public GameObject preguntaPanel;
    public GameObject respuestaPanel;

    private int preguntaActual = 0;
    private int respuestasCorrectas = 0;

    //private SaveSystem saveSystem;
    //private LevelUnlocker levelUnlocker;

    void Start()
    {
        //saveSystem = FindObjectOfType<SaveSystem>();
        //levelUnlocker = FindObjectOfType<LevelUnlocker>();

        MostrarPregunta();
        botonSiguiente.onClick.AddListener(MostrarRespuestas);
    }

    void MostrarPregunta()
    {
        preguntaPanel.SetActive(true);
        respuestaPanel.SetActive(false);
        textoPregunta.text = preguntas[preguntaActual].textoPregunta;
    }

    void MostrarRespuestas()
    {
        preguntaPanel.SetActive(false);
        respuestaPanel.SetActive(true);
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
        if (index == preguntas[preguntaActual].respuestaCorrecta)
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
        if (respuestasCorrectas == preguntas.Length)
        {
            // Guardar progreso y desbloquear niveles
            //int currentVillainLevel = GetCurrentVillainLevel();
            //int currentDetectiveLevel = GetCurrentDetectiveLevel();

            //saveSystem.SaveProgress(currentDetectiveLevel, currentVillainLevel);
            //levelUnlocker.UnlockLevels(currentDetectiveLevel, currentVillainLevel);

            SceneManager.LoadScene("Cutscene Victoria Villano");
        }
        else
        {
            SceneManager.LoadScene("Pantalla Derrota Villano Interrogatorio");
        }
    }

    /*private int GetCurrentVillainLevel()
    {
        return PlayerPrefs.GetInt("VillainLevel", 0);
    }

    private int GetCurrentDetectiveLevel()
    {
        return PlayerPrefs.GetInt("DetectiveLevel", 0);
    }*/
}