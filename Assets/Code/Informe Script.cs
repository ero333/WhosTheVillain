using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;

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

    public void OnEvidenceClick(int index)
    {
        evidenceIndices[index] = (evidenceIndices[index] + 1) % evidenceSprites.Length;
        evidenceImages[index].sprite = evidenceSprites[evidenceIndices[index]];
        UpdateHypothesis();
    }

    public void OnSuspectClick()
    {
        suspectIndex = (suspectIndex + 1) % suspectSprites.Length;
        suspectImage.sprite = suspectSprites[suspectIndex];
        suspectDescription.text = suspectDescriptions[suspectIndex];
        UpdateHypothesis();
    }

    public void OnMotiveClick()
    {
        motiveIndex = (motiveIndex + 1) % motives.Length;
        motiveText.text = motives[motiveIndex];
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
            SceneManager.LoadScene(victorySceneName);
        }
        else
        {
            SceneManager.LoadScene(defeatSceneName);
        }
    }
}