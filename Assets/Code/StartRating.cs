using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Analytics;
using System.Collections.Generic;

public class StarRating : MonoBehaviour
{
    public Button reviewButton;
    public Sprite emptyStar; // Asigna la imagen de la estrella vacía en el Inspector
    public Sprite filledStar; // Asigna la imagen de la estrella llena en el Inspector
    public Button submitButton; // Asigna el botón de enviar en el Inspector
    public RatingSection[] ratingSections; // Asigna los apartados en el Inspector

    public GameObject ratingMenu;


    void Start()
    {
        reviewButton.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("Level1Completed", 0) == 1)
        {
            reviewButton.gameObject.SetActive(true);
        }

        // Añadir el listener al botón de enviar
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(OnSubmitClick);
        }

        // Inicializar cada sección de puntuación
        foreach (RatingSection section in ratingSections)
        {
            section.Initialize();
        }
    }

    private void OnSubmitClick()
    {
        int ultimoNivelDesbloqueado = GuardarDatos.Instancia.NivelesDesbloqueados;

        string logMessage = $"Rate: Art: {ratingSections[0].rating}, Story: {ratingSections[1].rating}, Fun: {ratingSections[2].rating}, Level: {ultimoNivelDesbloqueado}";

        Debug.Log(logMessage);

        Unity.Services.Analytics.CustomEvent rateEvent = new Unity.Services.Analytics.CustomEvent("Rate")
        {
            { "art", ratingSections[0].rating },
            { "story", ratingSections[1].rating },
            { "fun", ratingSections[2].rating },
            { "level", ultimoNivelDesbloqueado }
        };

        AnalyticsService.Instance.RecordEvent(rateEvent);
        AnalyticsService.Instance.Flush();

        if (ratingMenu != null)
        {
            ratingMenu.SetActive(false);
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
    public string sectionName; // Nombre del apartado (arte, historia, diversión)
    public Button[] stars; // Botones de estrellas para este apartado
    public Sprite emptyStar; // Imagen de la estrella vacía
    public Sprite filledStar; // Imagen de la estrella llena
    [HideInInspector]
    public int rating; // Puntuación actual

    public void Initialize()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            int index = i; // Capturar el índice actual
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
