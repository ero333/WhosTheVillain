using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;
using System;

public class InformeScript : MonoBehaviour
{
    // Evidencias
    [Header("Evidencias")]
    public Image[] evidenceImages;
    public Sprite[] evidenceSprites;
    public string[] evidenceNames;
    public Sprite placeholderSprite; //Sprite de signo de interrogación
    private int[] evidenceIndices;

    // Sospechosos
    public Image suspectImage;
    public Text suspectDescription;
    public Sprite[] suspectSprites;
    public string[] suspectNames;
    public string[] suspectDescriptions;
    public Sprite suspectPlaceholderSprite; //Sprite de signo de interrogación
    private int suspectIndex = 0;

    // Motivos
    public Text motiveText;
    public string[] motives;
    private int motiveIndex = 0;
    private string initialMotiveText = "¿Por qué lo hizo?"; //Texto inicial

    // Hipótesis
    public Text hypothesisText;

    // Respuestas correctas
    public string correctEvidence1;
    public string correctEvidence2;
    public string correctEvidence3;
    public string correctSuspect;
    public string correctMotive;

    public bool Evidencia1Correcta;
    public bool Evidencia2Correcta;
    public bool Evidencia3Correcta;
    public bool SospechosoCorrecto;
    public bool MotivoCorrecto;
    public string TresOpcionesCorrectas;

    public string victoryScene;
    public string defeatScene;

    // Botón enviar informe
    public Button submitButton;

    public string[] pistasCombinaciones = new string[]
    {
        "111", "112", "113", "114", "115",
        "121", "122", "123", "124", "125",
        "131", "132", "133", "134", "135",
        "141", "142", "143", "144", "145",
        "151", "152", "153", "154", "155",
        "211", "212", "213", "214", "215",
        "221", "222", "223", "224", "225",
        "231", "232", "233", "234", "235",
        "241", "242", "243", "244", "245",
        "251", "252", "253", "254", "255",
        "311", "312", "313", "314", "315",
        "321", "322", "323", "324", "325",
        "331", "332", "333", "334", "335",
        "341", "342", "343", "344", "345",
        "351", "352", "353", "354", "355",
        "411", "412", "413", "414", "415",
        "421", "422", "423", "424", "425",
        "431", "432", "433", "434", "435",
        "441", "442", "443", "444", "445",
        "451", "452", "453", "454", "455",
        "511", "512", "513", "514", "515",
        "521", "522", "523", "524", "525",
        "531", "532", "533", "534", "535",
        "541", "542", "543", "544", "545",
        "551", "552", "553", "554", "555"
    };

    //private SaveSystem saveSystem;
    //private LevelUnlocker levelUnlocker;

    void Start()
    {
        //saveSystem = FindObjectOfType<SaveSystem>();
        //levelUnlocker = FindObjectOfType<LevelUnlocker>();

        evidenceIndices = new int[evidenceImages.Length];
        for (int i = 0; i < evidenceImages.Length; i++)
        {
            evidenceImages[i].sprite = placeholderSprite; //Imagen inicial
            evidenceIndices[i] = 0;
        }
        suspectImage.sprite = suspectPlaceholderSprite; //Imagen inicial
        suspectDescription.text = ""; // Descripción vacía
        motiveText.text = initialMotiveText; // Texto inicial

        submitButton.interactable = false; // Bloquear el botón al inicio

        UpdateHypothesis();
    }

    void Update()
    {
        TresOpcionesCorrectas = correctEvidence1 + correctEvidence2 + correctEvidence3;
        Evidencia1Correcta = (TresOpcionesCorrectas.Contains(evidenceImages[0].sprite.name));
        if (Evidencia1Correcta) TresOpcionesCorrectas = TresOpcionesCorrectas.Replace(evidenceImages[0].sprite.name, " ");
        Evidencia2Correcta = (TresOpcionesCorrectas.Contains(evidenceImages[1].sprite.name));
        if (Evidencia2Correcta) TresOpcionesCorrectas = TresOpcionesCorrectas.Replace(evidenceImages[1].sprite.name, " ");
        Evidencia3Correcta = (TresOpcionesCorrectas.Contains(evidenceImages[2].sprite.name));
        if (Evidencia3Correcta) TresOpcionesCorrectas = TresOpcionesCorrectas.Replace(evidenceImages[2].sprite.name, " ");
        SospechosoCorrecto = suspectImage.sprite.name == correctSuspect;
        MotivoCorrecto = motiveText.text == correctMotive;

        CheckIfFieldsAreComplete(); // Verificar si todos los campos están completos
    }

    void CheckIfFieldsAreComplete()
    {
        bool allFieldsComplete =
            evidenceImages[0].sprite != placeholderSprite &&
            evidenceImages[1].sprite != placeholderSprite &&
            evidenceImages[2].sprite != placeholderSprite &&
            suspectImage.sprite != suspectPlaceholderSprite &&
            motiveText.text != initialMotiveText;

        submitButton.interactable = allFieldsComplete; // Habilitar o deshabilitar el botón según sea necesario
    }

    private int[] pistasSeleccionadas = new int[3];
    public void OnEvidenceClick(int index)
    {
        // Cambiar la imagen del sprite de la pista
        evidenceIndices[index] = (evidenceIndices[index] + 1) % evidenceSprites.Length;
        evidenceImages[index].sprite = evidenceSprites[evidenceIndices[index]]; // Actualizar la imagen del sprite

        // Almacenar el número de pista seleccionado en la posición correspondiente
        pistasSeleccionadas[index] = evidenceIndices[index] + 1; // +1 para que las pistas comiencen en 1
        Debug.Log("Pista seleccionada: " + pistasSeleccionadas[index] + " en la posición: " + index);

        // Comprobar cuántas pistas han sido seleccionadas
        int seleccionadasCount = Array.FindAll(pistasSeleccionadas, pista => pista != 0).Length;

        if (seleccionadasCount == 3)
        {
            Debug.Log("Se han seleccionado 3 pistas: " + pistasSeleccionadas[0] + ", " + pistasSeleccionadas[1] + ", " + pistasSeleccionadas[2]);
        }

        UpdateHypothesis();
    }

    public void OnSuspectClick()
    {
        suspectIndex = (suspectIndex + 1) % suspectSprites.Length;
        suspectImage.sprite = suspectSprites[suspectIndex];
        suspectDescription.text = suspectDescriptions[suspectIndex];
        Debug.Log("Sospechoso seleccionado: " + suspectNames[suspectIndex]);

        UpdateHypothesis();
    }

    public void OnMotiveClick()
    {
        motiveIndex = (motiveIndex + 1) % motives.Length;
        motiveText.text = motives[motiveIndex];
        Debug.Log("Motivo seleccionado: " + motives[motiveIndex]);

        UpdateHypothesis();
    }

    void UpdateHypothesis()
    {
        string evidence1 = evidenceImages[0].sprite.name != placeholderSprite.name ? evidenceNames[evidenceIndices[0]] : "evidencia no seleccionada";
        string evidence2 = evidenceImages[1].sprite.name != placeholderSprite.name ? evidenceNames[evidenceIndices[1]] : "evidencia no seleccionada";
        string evidence3 = evidenceImages[2].sprite.name != placeholderSprite.name ? evidenceNames[evidenceIndices[2]] : "evidencia no seleccionada";
        string suspect = suspectImage.sprite.name != suspectPlaceholderSprite.name ? suspectNames[suspectIndex] : "sospechoso no seleccionado";
        string motive = motiveText.text != initialMotiveText ? motiveText.text : "motivo no seleccionado";
        hypothesisText.text = $"El sospechoso {suspect} fue identificado como el culpable. Las evidencias encontradas en su contra son: {evidence1}, {evidence2}, y {evidence3}. Pienso que el motivo del crimen fue porque: {motive}";
    }

    public string ObtenerCombinacionPistas(int[] indicesSeleccionados)
    {
        string combinacion = "";

        foreach (int index in indicesSeleccionados)
        {
            if (index != 0) // Asegúrate de no incluir los valores predeterminados
            {
                combinacion += index.ToString();
            }
        }

        // Asegúrate de que la combinación tenga una longitud adecuada (debería ser 3)
        if (combinacion.Length < 3)
        {
            Debug.LogWarning("No se han seleccionado suficientes pistas.");
            return ""; // O un valor predeterminado que tenga sentido
        }

        return combinacion;
    }

    public void OnSubmit(int X)
    {
        string victorySceneName = victoryScene;
        string defeatSceneName = defeatScene;


        if (Evidencia1Correcta && Evidencia2Correcta && Evidencia3Correcta &&
            suspectImage.sprite.name == correctSuspect &&
            motiveText.text == correctMotive)
        {
            PlayerPrefs.SetInt("Level1Completed", 1);
            PlayerPrefs.Save();

            GuardarDatos.Instancia.GuardarProgreso(X);

            PlayerPrefs.SetInt("CurrentLevel", X);
            PlayerPrefs.Save();

            // Guardar el progreso y desbloquear niveles
            //saveSystem.SaveProgress(currentDetectiveLevel, 0); // Asumiendo que el nivel del villano es 0 aquí
            //levelUnlocker.UnlockLevels(currentDetectiveLevel, 0);

            Unity.Services.Analytics.CustomEvent levelcompleteEvent = new Unity.Services.Analytics.CustomEvent("LevelComplete")
            {
                { "level", X },
                { "InfoClue", InventoryManager.Instance.InfoClueUsed },
            };

            AnalyticsService.Instance.RecordEvent(levelcompleteEvent);
            Debug.Log("LevelComplete: " + X + " ,InfoClueUsed: " + InventoryManager.Instance.InfoClueUsed);

            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            string combinacionPistas = ObtenerCombinacionPistas(pistasSeleccionadas);
            string suspect = suspectNames[suspectIndex];
            int motive = motiveIndex + 1;

            Unity.Services.Analytics.CustomEvent gameOverEvent = new Unity.Services.Analytics.CustomEvent("GameOver")
            {
              { "level", X },
              { "suspect", suspect },
              { "motive", motive },
              { "clues", combinacionPistas}, // Incluir la combinación de pistas
              { "InfoClue", InventoryManager.Instance.InfoClueUsed }
            };

            AnalyticsService.Instance.RecordEvent(gameOverEvent);
            Debug.Log("GameOver: " + X + ", pistas: " + combinacionPistas + ", sospechoso: " + suspect + ", motivo: " + motive + ", InfoClueUsed: " + InventoryManager.Instance.InfoClueUsed);

            SceneManager.LoadScene(defeatSceneName);
        }
    }
}