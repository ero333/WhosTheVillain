using UnityEngine;
using UnityEngine.UI;

public class BarraVillano : MonoBehaviour
{
    public Image progressBar;
    public float fillSpeed = 0.1f;
    public bool isFilling = false;
    public GameObject objetoActual;  // Objeto que actualmente está llenando la barra

    private void Update()
    {
        if (isFilling)
        {
            progressBar.fillAmount += fillSpeed * Time.deltaTime;
            if (progressBar.fillAmount >= 1)
            {
                progressBar.fillAmount = 0;
                isFilling = false;

                if (objetoActual != null)
                {
                    // Intenta obtener el sprite del objeto antes de destruirlo
                    Image imagenDelObjeto = objetoActual.GetComponent<Image>();
                    if (imagenDelObjeto != null && imagenDelObjeto.sprite != null)
                    {
                        VillanoInventoryManager.Instance.AgregarObjeto(imagenDelObjeto.sprite);
                    }
                    else
                    {
                        Debug.LogWarning("El objeto no tiene sprite asignado.");
                    }

                    Destroy(objetoActual);  // Destruye el objeto cuando la barra se completa
                    objetoActual = null;    // Reinicia la referencia
                }
            }
        }
    }

    public void StartFilling(GameObject nuevoObjeto)
    {
        // Si el objeto actual es diferente al nuevo, reinicia la barra
        if (objetoActual != nuevoObjeto)
        {
            progressBar.fillAmount = 0;  // Reinicia el progreso de la barra
            objetoActual = nuevoObjeto;  // Actualiza el objeto actual
        }

        isFilling = true;
    }

    public void StopFilling()
    {
        isFilling = false;
    }
}