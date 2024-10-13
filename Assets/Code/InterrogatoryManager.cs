using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InterrogatoryManager : MonoBehaviour
{

    
    public List<Personaje> personajes; // Lista de personajes 
    public GameObject imagenCajaPreguntas;
    public GameObject[] botonesPreguntas; // Los botones para las preguntas
    public TMP_Text NombrePersonaje;
    public Text RespuestaPersonaje;
    public GameObject CajaRespuesta;
    public Image[] imagenesPersonajes; // Las imágenes para cada personaje
    public GameObject BotonesSospechos; // Los botones para los sospechosos
    public GameObject BotonCambioEscena;

    private Personaje personajeActual;
    public int preguntasRestantes = 3;
    public int entrevistasRequeridas = 3;
    public int Entrevistas;

    //public Desbloqueador desbloqueador; // Referencia al Desbloqueador

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

        personajeActual = personajes[personaje];
        preguntasRestantes = 3;
        MostrarImagenPersonaje(personajeActual);
        MostrarCajaPreguntas();

        for (int i = 0; i < botonesPreguntas.Length; i++)
        {
            botonesPreguntas[i].GetComponent<Button>().interactable = true;
        }
    }

    public void ActivarRespuesta(int preguntaIndex)
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
                RespuestaPersonaje.text = x.preguntas[preguntaIndex].respuesta;

                DesactivarBotonPregunta(preguntaIndex);

                // Verificar si la respuesta es correcta
                if (x.preguntas[preguntaIndex].esCorrecta)
                {
                    x.CorrectAnswers++;
                    Debug.Log("Respuesta correcta para " + x.nombre);

                    // Desbloquear logro si se cumplen las condiciones
                   
                }
                else
                {
                    x.IncorrectAnswers++;
                    Debug.Log("Respuesta incorrecta para " + x.nombre);
                }
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
            personajeActual = null;
            BotonesSospechos.SetActive(true);
        }
    }

    private void DesactivarBotonPregunta(int preguntaIndex)
    {
        // Desactiva el botón de la pregunta correspondiente
        botonesPreguntas[preguntaIndex].GetComponent<Button>().interactable = false;
    }

    private void TerminarEntrevista()
    {
        if (Entrevistas == entrevistasRequeridas)
        {
            BotonCambioEscena.SetActive(true);
        }
    }

    public void PersonajeSeleccionado(Button PersonajeBoton)
    {
        PersonajeBoton.GetComponent<Button>().interactable = false;
    }
}


