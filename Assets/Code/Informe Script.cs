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
    public Sprite placeholderSprite; // Sprite de signo de interrogación
    private int[] evidenceIndices;

    // Sospechosos
    public Image suspectImage;
    public Text suspectDescription;
    public Sprite[] suspectSprites;
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
        hypothesisText.text = $"Evidencias: {evidenceImages[0].sprite.name}, {evidenceImages[1].sprite.name}, {evidenceImages[2].sprite.name}\n" +
                              $"Sospechoso: {suspectImage.sprite.name} - {suspectDescription.text}\n" +
                              $"Motivo: {motiveText.text}";
    }

    public void OnSubmit()
    {
        if (evidenceImages[0].sprite.name == correctEvidence1 &&
            evidenceImages[1].sprite.name == correctEvidence2 &&
            evidenceImages[2].sprite.name == correctEvidence3 &&
            suspectImage.sprite.name == correctSuspect &&
            motiveText.text == correctMotive)
        {
            SceneManager.LoadScene("VictoryScene");
        }
        else
        {
            SceneManager.LoadScene("DefeatScene");
        }
    }
}
