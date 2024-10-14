using UnityEngine;
using UnityEngine.UI;

public class StarRating : MonoBehaviour
{
    public Button reviewButton;
    public Sprite emptyStar; // Asigna la imagen de la estrella vac�a en el Inspector
    public Sprite filledStar; // Asigna la imagen de la estrella llena en el Inspector
    public Button submitButton; // Asigna el bot�n de enviar en el Inspector
    public RatingSection[] ratingSections; // Asigna los apartados en el Inspector

    void Start()
    {
        reviewButton.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1)
        {
            reviewButton.gameObject.SetActive(true);
        }

        // A�adir el listener al bot�n de enviar
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitClick);
        }

        // Inicializar cada secci�n de puntuaci�n
        foreach (RatingSection section in ratingSections)
        {
            section.Initialize();
        }
    }

    private void OnSubmitClick()
    {
        foreach (RatingSection section in ratingSections)
        {
            Debug.Log(section.sectionName + " Puntuaci�n: " + section.rating);
            // Aqu� puedes a�adir el c�digo para enviar la puntuaci�n a un servidor o guardarla localmente.
        }
    }

    public void ResetRatings()
    {
        foreach (RatingSection section in ratingSections)
        {
            section.Reset();
        }
    }
}

[System.Serializable]
public class RatingSection
{
    public string sectionName; // Nombre del apartado (arte, historia, diversi�n)
    public Button[] stars; // Botones de estrellas para este apartado
    public Sprite emptyStar; // Imagen de la estrella vac�a
    public Sprite filledStar; // Imagen de la estrella llena
    [HideInInspector]
    public int rating; // Puntuaci�n actual

    public void Initialize()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            int index = i; // Capturar el �ndice actual
            stars[i].onClick.AddListener(() => OnStarClick(index + 1));
        }
    }

    private void OnStarClick(int starIndex)
    {
        rating = starIndex;
        UpdateStars();
    }

    private void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            Image starImage = stars[i].GetComponent<Image>();
            if (i < rating)
            {
                starImage.sprite = filledStar;
            }
            else
            {
                starImage.sprite = emptyStar;
            }
        }
    }

    public void Reset()
    {
        rating = 0;
        UpdateStars();
    }
}
