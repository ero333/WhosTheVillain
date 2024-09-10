using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;  // Asigna tu Animator aquí

    void Update()
    {
        // Detectar si el clic izquierdo del ratón está presionado
        bool Sabotaje = Input.GetMouseButton(0);  // 0 es el botón izquierdo del ratón

        // Actualizar el parámetro en el Animator
        animator.SetBool("Sabotaje", Sabotaje);
    }
}
