using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public Animator animator;  // Asigna tu Animator aqu�

    void Update()
    {
        // Detectar si el clic izquierdo del rat�n est� presionado
        bool Sabotaje = Input.GetMouseButton(0);  // 0 es el bot�n izquierdo del rat�n

        // Actualizar el par�metro en el Animator
        animator.SetBool("Sabotaje", Sabotaje);
    }
}
