using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desbloqueador : MonoBehaviour
{
    public AchievementManager achievementManager;
    private HashSet<string> botonesClickeados = new HashSet<string>();
    private int totalBotones = 8; // Cambia esto al número total de botones

    // Método para registrar el clic en un botón
    public void BotonClickeado(string botonID)
    {
        if (!botonesClickeados.Contains(botonID))
        {
            botonesClickeados.Add(botonID);
            VerificarLogro();
        }
    }

    // Verificar si todos los botones han sido clickeados
    private void VerificarLogro()
    {
        if (botonesClickeados.Count == totalBotones)
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 1");
            Debug.Log("Logro desbloqueado: Amante de los detalles Caso 1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // Simula recoger un objeto al presionar la flecha izquierda
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 1");
            Debug.Log("Logro desbloqueado: Amante de los detalles Caso 1");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            achievementManager.UnlockAchievement("Interrogador nato Caso 1");
            Debug.Log("Logro desbloqueado: Interrogador nato Caso 1");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 2");
            Debug.Log("Logro desbloqueado: Amante de los detalles Caso 2");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            achievementManager.UnlockAchievement("Interrogador nato Caso 2");
            Debug.Log("Logro desbloqueado: Interrogador nato Caso 2");
        }
    }
}