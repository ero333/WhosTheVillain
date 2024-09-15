using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    [TextArea(4, 6)] public string itemDescrip;
    public Sprite itemIcon;
    public GameObject infoPanel;
    public Image itemImage;
    public Text itemText;
    public Button closeButton;
    public Button backbuttom;

    public GameObject subScenario;
    public GameObject mainScenario;

    private static int contador;
    public Button botoninforme;
    
    public Image flashEffect;
    public float flashDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (flashEffect != null )
        {
            flashEffect.gameObject.SetActive( false );
        }
        if (closeButton != null )
        {
            closeButton.onClick.AddListener(CloseInfoPanel);
        }
        if (infoPanel != null )
        {
            infoPanel.SetActive( false );
        }
        if (backbuttom != null)
        {
            backbuttom.onClick.AddListener(OnBackButtonClicked);
        }
    }

    private void OnMouseDown()
    {
        print(itemName);
        InventoryManager.Instance.AddItem(this);

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
        flashEffect.gameObject.SetActive ( true );
        yield return new WaitForSeconds(flashDuration);
        flashEffect.gameObject.SetActive ( false );
        Destroy(gameObject);
    }

    private void ShowInfoPanel()
    {
        if (infoPanel != null)
        {
            if (itemImage != null)
            {
                itemImage.sprite = itemIcon;
            }
            if (itemText != null)
            {
                itemText.text = itemName;
            }

            infoPanel.SetActive(true);
        }
    }

    public void OnBackButtonClicked()
    {
        Debug.Log("Back button clicked");
        CloseInfoPanel();
        if (subScenario != null)
        {
            subScenario.SetActive(false);
        }
        if (mainScenario != null)
        {
            mainScenario.SetActive(true);
        }
    }

    private void CloseInfoPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }


}
