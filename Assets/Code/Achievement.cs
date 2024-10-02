using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string title; // T�tulo del logro
    public string description; // Descripci�n del logro
    public bool isUnlocked; // Estado del logro (desbloqueado o no)

    // Constructor para inicializar el logro
    public Achievement(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isUnlocked = false; // Inicializar como no desbloqueado
    }
}