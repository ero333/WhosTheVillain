using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{
    public Image image; // La imagen que quieres que cambie de opacidad

    [Header("Fade Settings")]
    public float fadeInSpeed = 1f; // Velocidad para cuando la opacidad aumenta (fade in)
    public float fadeOutSpeed = 1f; // Velocidad para cuando la opacidad disminuye (fade out)

    private float targetAlpha = 0f; // Objetivo de opacidad (0 para transparente, 1 para opaco)

    void Start()
    {
        // Asegurarnos de que la imagen comienza con opacidad 0 al inicio
        SetAlpha(0f);
    }

    void Update()
    {
        // Detectamos si el click está siendo presionado
        if (Input.GetMouseButton(0)) // 0 es el click izquierdo
        {
            targetAlpha = 1f; // Queremos que la opacidad llegue a 100% cuando se presiona el click
        }
        else
        {
            targetAlpha = 0f; // Queremos que la opacidad vuelva a 0% cuando se suelta el click
        }

        // Modificar la opacidad de la imagen gradualmente
        float currentAlpha = image.color.a; // Obtener el valor actual de opacidad

        // Seleccionar la velocidad de desvanecimiento basada en si estamos haciendo fade in o fade out
        float speed = (targetAlpha == 1f) ? fadeInSpeed : fadeOutSpeed;

        // Usamos Mathf.MoveTowards para cambiar la opacidad suavemente
        float newAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, speed * Time.deltaTime);

        // Asignamos el nuevo color a la imagen manteniendo el RGB igual, solo cambiando el alfa
        image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
    }

    // Método auxiliar para configurar la opacidad directamente
    private void SetAlpha(float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}
