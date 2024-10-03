using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Personaje
{
    public string nombre;
    public List<Pregunta> preguntas;
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}

[System.Serializable]
public class Pregunta
{
    public string texto;
    public string respuesta;
    public bool esCorrecta;
}