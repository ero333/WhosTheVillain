using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrogatoryManager : MonoBehaviour
{
    public List<Personaje> personajes; // Lista de personajes 
    public Image imagenCajaPreguntas;
    public GameObject[] botonesPreguntas; // Los botones para las preguntas
    public GameObject[] cajasTextoRespuestas; // Los GameObjects para mostrar respuestas
    public Image[] imagenesPersonajes; // Las imágenes para cada personaje

    private Personaje personajeActual;
    private int preguntasRestantes = 3;

    void Start()
    {
        // Configura el estado inicial del juego
        imagenCajaPreguntas.gameObject.SetActive(false);
        foreach (var boton in botonesPreguntas)
        {
            boton.GetComponent<Button>().onClick.AddListener(() => HacerPregunta(boton.GetComponentInChildren<Text>().text));
        }
        foreach (var caja in cajasTextoRespuestas)
        {
            caja.SetActive(false);
        }
    }

    public void SeleccionarPersonaje(Personaje personaje)
    {
        personajeActual = personaje;
        preguntasRestantes = 3; // Reiniciar el número de preguntas
        MostrarImagenPersonaje(personaje);
        MostrarCajaPreguntas();
    }

    private void MostrarImagenPersonaje(Personaje personaje)
    {
        for (int i = 0; i < imagenesPersonajes.Length; i++)
        {
            imagenesPersonajes[i].gameObject.SetActive(personajes[i] == personaje);
        }
    }

    private void MostrarCajaPreguntas()
    {
        imagenCajaPreguntas.gameObject.SetActive(true);
    }

    private void HacerPregunta(string preguntaTexto)
    {
        if (preguntasRestantes > 0 && personajeActual != null)
        {
            foreach (var pregunta in personajeActual.preguntas)
            {
                if (pregunta.texto == preguntaTexto)
                {
                    MostrarRespuesta(pregunta.respuesta);
                    preguntasRestantes--;
                    break;
                }
            }
            if (preguntasRestantes <= 0)
            {
                TerminarEntrevista();
            }
        }
    }

    private void MostrarRespuesta(string respuesta)
    {
        foreach (var caja in cajasTextoRespuestas)
        {
            if (!caja.activeSelf)
            {
                caja.SetActive(true);
                caja.GetComponentInChildren<Text>().text = respuesta;
                break;
            }
        }
    }

    private void TerminarEntrevista()
    {
        imagenCajaPreguntas.gameObject.SetActive(false);
        personajeActual = null;
    }
}

