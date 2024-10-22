using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    private void Awake()
    {
        // Asegurarse de que el tiempo no esté pausado
        Time.timeScale = 1f;
        Debug.Log("Escena inicializada: " + SceneManager.GetActiveScene().name);
    }
}