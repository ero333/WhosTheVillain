using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string initialScene;
    private string currentLevel;
    private Button retryButton;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // No asignar el botón aquí
    }

    void Update()
    {
        // Buscar el botón dinámicamente si aún no está asignado
        if (retryButton == null)
        {
            retryButton = GameObject.FindWithTag("RetryButton")?.GetComponent<Button>();
            if (retryButton != null)
            {
                retryButton.onClick.AddListener(RestartLevel);
            }
        }
    }

    public void SetInitialScene(string levelName, string sceneName)
    {
        currentLevel = levelName;
        initialScene = sceneName;
    }

    public void RestartLevel()
    {
        if (!string.IsNullOrEmpty(initialScene))
        {
            SceneManager.LoadScene(initialScene);
        }
        else
        {
            Debug.LogError("No initial scene set for the current level.");
        }
    }
}
