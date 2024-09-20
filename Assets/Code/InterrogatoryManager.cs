using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterrogatoryManager : MonoBehaviour
{
    public List<Personaje> personajes; // Lista de personajes 
    public GameObject imagenCajaPreguntas;
    public GameObject[] botonesPreguntas; // Los botones para las preguntas
    // public GameObject[] cajasTextoRespuestas; // Los GameObjects para mostrar respuestas
    public TMP_Text NombrePersonaje;
    public Text RespuestaPersonaje;
    public GameObject CajaRespuesta;
    public Image[] imagenesPersonajes; // Las imágenes para cada personaje
    public GameObject BotonesSospechos; //Los botones para los sospechosos
    public GameObject BotonCambioEscena;

    private Personaje personajeActual;
    public int preguntasRestantes = 3;
    public int entrevistasRequeridas = 3;

    void Start()
    {
        // Configura el estado inicial del juego
        imagenCajaPreguntas.gameObject.SetActive(false);
    }

    private void Update()
    {
        TerminarEntrevista();
    }

    public void SeleccionarPersonaje(int personaje)
    {
        DesactivarBotones();
       
        if (personaje == 0)
        {
            personajeActual = personajes[0];
            preguntasRestantes = 3;
            MostrarImagenPersonaje(personajeActual);
        }
        else if (personaje == 1)
        {
            personajeActual = personajes[1];
            preguntasRestantes = 3;
            MostrarImagenPersonaje(personajeActual);
        }
        else if (personaje == 2)
        {
            personajeActual = personajes[2];
            preguntasRestantes = 3;
            MostrarImagenPersonaje(personajeActual);
        }
        else if (personaje == 3)
        {
            personajeActual = personajes[3];
            preguntasRestantes = 3;
            MostrarImagenPersonaje (personajeActual);
        }

        MostrarCajaPreguntas();

    }

    public void ActivarRespuesta(int preguntas)
    {
        for (int i = 0; i < botonesPreguntas.Length; i++)
        {
            botonesPreguntas[i].gameObject.SetActive(false);
            imagenCajaPreguntas.gameObject.SetActive(false);
        }
        foreach (Personaje x in personajes)
        {
            if (personajeActual == x)
            {
                CajaRespuesta.SetActive(true);
                NombrePersonaje.text = x.nombre;
                RespuestaPersonaje.text = x.preguntas[preguntas].respuesta;
            }
        }
        preguntasRestantes--;
    }

    private void DesactivarBotones()
    {
        BotonesSospechos.SetActive(false);
    }

    private void MostrarImagenPersonaje(Personaje personaje)
    {
        if (preguntasRestantes > 0)
        {
            for (int i = 0; i < imagenesPersonajes.Length; i++)
            {
                imagenesPersonajes[i].gameObject.SetActive(personajes[i] == personaje);
            }
        }
        else
        {
            imagenCajaPreguntas.gameObject.SetActive(false);
            for (int i = 0; i < imagenesPersonajes.Length; i++)
            {
                if (imagenesPersonajes[i].gameObject.activeSelf)
                    imagenesPersonajes[i].gameObject.SetActive(false);
            }
        }
    }

    public void MostrarCajaPreguntas()
    {
        if (preguntasRestantes > 0)
        {
            imagenCajaPreguntas.gameObject.SetActive(true);
            for (int i = 0; i < botonesPreguntas.Length; i++)
            {
                botonesPreguntas[i].gameObject.SetActive(true);
            }
        }
        else
        {
            Entrevistas++;
            MostrarImagenPersonaje(personajeActual);
            //imagenCajaPreguntas.gameObject.SetActive(false);
            personajeActual = null;
            BotonesSospechos.SetActive(true);
        }
    }

    private void TerminarEntrevista()
    {
        if (Entrevistas == entrevistasRequeridas) //Poner variable en el inspector
        {
            BotonCambioEscena.SetActive(true);
        }
    }

    public int Entrevistas;

    public void PersonajeSeleccionado(Button PersonajeBoton)
    {
        PersonajeBoton.GetComponent<Button>().interactable = false;
    }
}

