using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Pregunta
{
    public string texto;
    public string respuesta;
}

[System.Serializable]
public class Personaje
{
    public string nombre;
    public Image imagen;
    public List<Pregunta> preguntas;
}

