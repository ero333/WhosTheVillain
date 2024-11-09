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
            message = "Tienes una evidencia errónea.";
        }
        else if (!informeScript.SospechosoCorrecto)
        {
            message = "Tienes un sospechoso erróneo.";
        }
        else if (!informeScript.MotivoCorrecto)
        {
            message = "Tienes un motivo erróneo.";
        }
        else
        {
            message = "No hay nada extraño."; // Nuevo mensaje si todo está correcto
        }

        // Mostrar el mensaje en el panel de ayuda
        helpText.text = message;
        helpPanel.SetActive(true);

        // Ocultar el panel después de 6 segundos
        StartCoroutine(HideHelpPanel());
    }

    private IEnumerator HideHelpPanel()
    {
        yield return new WaitForSeconds(6f);
        helpPanel.SetActive(false);
    }
}
