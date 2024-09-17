using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class InformeScript : MonoBehaviour
{
    // Evidencias
    public Image[] evidenceImages;
    public Sprite[] evidenceSprites;
    public string[] evidenceNames;
    public Sprite placeholderSprite; // Sprite de signo de interrogación
    private int[] evidenceIndices;

    // Sospechosos
    public Image suspectImage;
    public Text suspectDescription;
    public Sprite[] suspectSprites;
    public string[] suspectNames;
    public string[] suspectDescriptions;
    public Sprite suspectPlaceholderSprite; // Sprite de signo de interrogación
    private int suspectIndex = 0;

    // Motivos
    public Text motiveText;
    public string[] motives;
    private int motiveIndex = 0;
    private string initialMotiveText = "¿Por qué lo hizo?"; // Texto inicial

    // Hipótesis
    public Text hypothesisText;

    // Respuestas correctas
    public string correctEvidence1;
    public string correctEvidence2;
    public string correctEvidence3;
    public string correctSuspect;
    public string correctMotive;

    void Start()
    {
        evidenceIndices = new int[evidenceImages.Length];
        for (int i = 0; i < evidenceImages.Length; i++)
        {
            evidenceImages[i].sprite = placeholderSprite; // Imagen inicial
            evidenceIndices[i] = 0;
        }
        suspectImage.sprite = suspectPlaceholderSprite; // Imagen inicial
        suspectDescription.text = ""; // Descripción vacía
        motiveText.text = initialMotiveText; // Texto inicial
        UpdateHypothesis();
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

        hypothesisText.text = $"El sospechoso {suspect} fue identificado como el culpable. Las evidencias encontradas en su contra son: {evidence1}, {evidence2}, y {evidence3}. Pienso que motivo del crimen fue porque: {motive}";
    }

    public void OnSubmit()
    {
        if (evidenceImages[0].sprite.name == correctEvidence1 &&
            evidenceImages[1].sprite.name == correctEvidence2 &&
            evidenceImages[2].sprite.name == correctEvidence3 &&
            suspectImage.sprite.name == correctSuspect &&
            motiveText.text == correctMotive)
        {
            SceneManager.LoadScene("Pantalla Victoria");
        }
        else
        {
            SceneManager.LoadScene("Cutscene Derrota D");
        }
    }
}
