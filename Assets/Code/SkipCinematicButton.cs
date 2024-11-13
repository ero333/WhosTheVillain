using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipCinematicButton : MonoBehaviour
{
    public Button skipbutton;
    public string cinematicName; // Nombre �nico para la cinem�tica (por ejemplo, el nombre de la escena)

    private string cinematicKey;

    void Start()
    {
        // Define la clave �nica para esta cinem�tica
        cinematicKey = "CinematicSeen_" + cinematicName;

        // Si la cinem�tica ya fue vista, activa el bot�n de omitir
        if (PlayerPrefs.GetInt(cinematicKey, 0) == 1)
        {
            skipbutton.gameObject.SetActive(true);
        }
        else
        {
            // Si es la primera vez que se ve, oculta el bot�n y marca la cinem�tica como vista
            skipbutton.gameObject.SetActive(false);
            PlayerPrefs.SetInt(cinematicKey, 1);
            PlayerPrefs.Save();
        }
    }
}