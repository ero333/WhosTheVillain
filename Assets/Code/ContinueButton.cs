using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private SaveSystem saveSystem;

    void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }

    public void Continue()
    {
        int lastDetectiveLevel = PlayerPrefs.GetInt("DetectiveLevel", 0);
        int lastVillainLevel = PlayerPrefs.GetInt("VillainLevel", 0);
        int lastLevel = Mathf.Max(lastDetectiveLevel, lastVillainLevel);

        // Asumiendo que los niveles están numerados secuencialmente en el build settings
        SceneManager.LoadScene(lastLevel);
    }
}
