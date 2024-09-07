using UnityEngine;
using UnityEngine.SceneManagement; 

public class DestructionCounter : MonoBehaviour
{
    public static int destructionCount = 0;

    private void OnDestroy()
    {
        destructionCount++;
        Debug.Log("Número de destrucciones: " + destructionCount);

        if (destructionCount >= 5)
        {
 
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
  
        SceneManager.LoadScene("Pantalla Victoria Villano");
    }
}
