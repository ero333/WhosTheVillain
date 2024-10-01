using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string title; // Título del logro
    public string description; // Descripción del logro
    public bool isUnlocked; // Estado del logro (desbloqueado o no)
}