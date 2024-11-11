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
                    Destroy(objetoActual);  // Destruye el objeto cuando la barra se completa
                    objetoActual = null;  // Reinicia la referencia del objeto actual
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
