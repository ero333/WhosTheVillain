using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    public GameObject helpPanel;
    public TMP_Text helpText; // Cambiado a TMP_Text para TextMeshPro
    public Button helpButton;

    private InformeScript informeScript;
    private bool helpUsed = false;

    void Start()
    {
        helpPanel.SetActive(false);
        helpButton.interactable = false;

        informeScript = FindObjectOfType<InformeScript>();
    }

    void Update()
    {
        if (informeScript != null && !helpUsed)
        {
            bool allFieldsComplete = informeScript.evidenceImages[0].sprite != informeScript.placeholderSprite &&
                                     informeScript.evidenceImages[1].sprite != informeScript.placeholderSprite &&
                                     informeScript.evidenceImages[2].sprite != informeScript.placeholderSprite &&
                                     informeScript.suspectImage.sprite != informeScript.suspectPlaceholderSprite &&
                                     informeScript.motiveText.text != informeScript.initialMotiveText;

            helpButton.interactable = allFieldsComplete;
        }
    }

    public void OnHelpButtonClick()
    {
        if (informeScript == null) return;

        string message = "";

        if (!informeScript.Evidencia1Correcta || !informeScript.Evidencia2Correcta || !informeScript.Evidencia3Correcta)
        {
            message = "Tienes una evidencia err�nea.";
        }
        else if (!informeScript.SospechosoCorrecto)
        {
            message = "Tienes un sospechoso err�neo.";
        }
        else if (!informeScript.MotivoCorrecto)
        {
            message = "Tienes un motivo err�neo.";
        }
        else
        {
            message = "No hay nada extra�o."; // Nuevo mensaje si todo est� correcto
        }

        // Mostrar el mensaje en el panel de ayuda
        helpText.text = message;
        helpPanel.SetActive(true);

        // Ocultar el panel despu�s de 6 segundos
        StartCoroutine(HideHelpPanel());
    }

    private IEnumerator HideHelpPanel()
    {
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
    }
}
