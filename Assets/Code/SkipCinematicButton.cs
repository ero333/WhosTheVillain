using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipCinematicButton : MonoBehaviour
{
    public Button skipbutton;
    public string cinematicName; // Nombre único para la cinemática (por ejemplo, el nombre de la escena)

    private string cinematicKey;

    void Start()
    {
        // Define la clave única para esta cinemática
        cinematicKey = "CinematicSeen_" + cinematicName;

        // Si la cinemática ya fue vista, activa el botón de omitir
        if (PlayerPrefs.GetInt(cinematicKey, 0) == 1)
        {
            skipbutton.gameObject.SetActive(true);
        }
        else
        {
            // Si es la primera vez que se ve, oculta el botón y marca la cinemática como vista
            skipbutton.gameObject.SetActive(false);
            PlayerPrefs.SetInt(cinematicKey, 1);
            PlayerPrefs.Save();
        }
    }
}