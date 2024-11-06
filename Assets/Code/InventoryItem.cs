using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Analytics;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    public string clueName; // Nueva variable para el nombre de la pista
    [TextArea(4, 6)] public string itemDescrip;
    public Sprite itemIcon;

    public Button backButton;

    public GameObject subScenario;
    public GameObject mainScenario;

    public Button botoninforme;

    public Image flashEffect;
    public float flashDuration = 0.1f;

    private static int contador;
    private bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        if (flashEffect != null)
        {
            flashEffect.gameObject.SetActive(false);
        }
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    private void OnMouseDown()
    {
        if (isCollected) return;

        // Obtener el tiempo transcurrido
        Timer timer = FindObjectOfType<Timer>();
        int tiempo = timer.GetElapsedTime();

        // Obtener el nivel actual
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        // Incrementar el contador de orden
        contador++;

        Debug.Log("Tiempo transcurrido: " + tiempo + " segundos.");
        Debug.Log("Nivel actual: " + currentLevel);
        Debug.Log("Orden de recolección: " + contador);
        Debug.Log("Nombre de la pista: " + clueName); // Agregar un log para el nombre de la pista

        // Crear el evento de análisis
        Unity.Services.Analytics.CustomEvent findclueEvent = new Unity.Services.Analytics.CustomEvent("FindClue")
        {
            { "time", tiempo },
            { "orden", contador },
            { "levelD", currentLevel },
            { "clue", clueName }
        };

        AnalyticsService.Instance.RecordEvent(findclueEvent);
        Debug.Log("FindClue: " + "time: " + tiempo + ", orden: " + contador + ", levelD: " + currentLevel + ", clue: " + clueName);

        InventoryManager.Instance.AddItem(this);
        isCollected = true;

        if (flashEffect != null)
        {
            ShowInfoPanel();
            StartCoroutine(ShowFlashEffect());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowFlashEffect()
    {
        flashEffect.gameObject.SetActive(true);
        yield return new WaitForSeconds(flashDuration);
        flashEffect.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void ShowInfoPanel()
    {
        InventoryManager.Instance.abrirInfoPanel(itemName, itemDescrip, itemIcon);
    }

    public void OnBackButtonClicked()
    {
        Debug.Log("Back button clicked");
        InventoryManager.Instance.CerrarInfoPanel();
        if (subScenario != null)
        {
            subScenario.SetActive(false);
        }
        if (mainScenario != null)
        {
            mainScenario.SetActive(true);
        }
    }
}
