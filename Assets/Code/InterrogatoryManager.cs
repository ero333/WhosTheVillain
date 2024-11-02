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
    public Button BotonSiguiente;

    private Personaje personajeActual;

    void Start()
    {
        // Configura el estado inicial del juego
        imagenCajaPreguntas.gameObject.SetActive(false);
        BotonCambioEscena.SetActive(true); // El botón de cambiar de escena está activado desde el principio

        if (BotonSiguiente != null)
        {
            BotonSiguiente.onClick.AddListener(VolverASospechos);
        }
    }

    public void SeleccionarPersonaje(int personajeIndex)
    {
        DesactivarBotones();

        personajeActual = personajes[personajeIndex];
        MostrarImagenPersonaje(personajeActual);
        MostrarCajaPreguntas();
    }

    public void ActivarRespuesta(int preguntaIndex)
    {
        for (int i = 0; i < botonesPreguntas.Length; i++)
        {
            botonesPreguntas[i].gameObject.SetActive(false);
            imagenCajaPreguntas.gameObject.SetActive(false);
        }

        Debug.Log("Question: " + preguntaIndex);

        CajaRespuesta.SetActive(true);
        NombrePersonaje.text = personajeActual.nombre;
        RespuestaPersonaje.text = personajeActual.preguntas[preguntaIndex].respuesta;

        // Verificar si la respuesta es correcta
        if (personajeActual.preguntas[preguntaIndex].esCorrecta)
        {
            personajeActual.CorrectAnswers++;
            Debug.Log("Respuesta correcta para " + personajeActual.nombre);
        }
        else
        {
            personajeActual.IncorrectAnswers++;
            Debug.Log("Respuesta incorrecta para " + personajeActual.nombre);
        }

        // Volver a la selección de sospechosos después de mostrar la respuesta
        BotonSiguiente.onClick.RemoveAllListeners();
        BotonSiguiente.onClick.AddListener(VolverASospechos);
    }

    private void DesactivarBotones()
    {
        BotonesSospechos.SetActive(false);
        BotonCambioEscena.SetActive(false); // Desactivar el botón de cambiar de escena
    }

    private void MostrarImagenPersonaje(Personaje personaje)
    {
        for (int i = 0; i < imagenesPersonajes.Length; i++)
        {
            imagenesPersonajes[i].gameObject.SetActive(personajes[i] == personaje);
        }
    }

    public void MostrarCajaPreguntas()
    {
        imagenCajaPreguntas.gameObject.SetActive(true);
        for (int i = 0; i < botonesPreguntas.Length; i++)
        {
            botonesPreguntas[i].gameObject.SetActive(true);
        }
    }

    public void VolverASospechos()
    {
        for (int i = 0; i < imagenesPersonajes.Length; i++)
        {
            imagenesPersonajes[i].gameObject.SetActive(false);
        }
        imagenCajaPreguntas.gameObject.SetActive(false);
        CajaRespuesta.SetActive(false);

        // Reactivar todos los botones de sospechosos
        ReactivarBotonesSospechos();

        BotonesSospechos.SetActive(true);
        BotonCambioEscena.SetActive(true); // Reactivar el botón de cambiar de escena
    }

    private void ReactivarBotonesSospechos()
    {
        for (int i = 0; i < BotonesSospechos.transform.childCount; i++)
        {
            BotonesSospechos.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }
}
