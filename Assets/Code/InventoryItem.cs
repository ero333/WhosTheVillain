using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string itemName;
    [TextArea(4, 6)] public string itemDescrip;
    public Sprite itemIcon;
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
    }

    // Update is called once per frame
  

    private void OnMouseDown()
    {
        print(itemName);
        InventoryManager.Instance.AddItem(this);

        if (flashEffect != null)
        {
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

}
