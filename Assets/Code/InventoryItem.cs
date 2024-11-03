using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    [TextArea(4, 6)] public string itemDescrip;
    public Sprite itemIcon;

    public Button backButton;

    public GameObject subScenario;
    public GameObject mainScenario;

    private static int contador;
    public Button botoninforme;

    public Image flashEffect;
    public float flashDuration = 0.1f;

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

        Debug.Log("FindClue");
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
