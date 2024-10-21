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
        public int respuestaCorrecta;
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
        string victorySceneName = victoryScene;
        string defeatSceneName = defeatScene;

        if (respuestasCorrectas == preguntas.Length)
        {
            GuardarDatos.Instancia.GuardarProgreso(NivelAGuardar);
            // Guardar progreso y desbloquear niveles
            //int currentVillainLevel = GetCurrentVillainLevel();
            //int currentDetectiveLevel = GetCurrentDetectiveLevel();

            PlayerPrefs.SetInt("CurrentLevel", NivelAGuardar);
            PlayerPrefs.Save();

            //saveSystem.SaveProgress(currentDetectiveLevel, currentVillainLevel);
            //levelUnlocker.UnlockLevels(currentDetectiveLevel, currentVillainLevel);
            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            SceneManager.LoadScene(defeatSceneName);
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