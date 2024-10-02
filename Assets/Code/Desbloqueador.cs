using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desbloqueador : MonoBehaviour
{
    public AchievementManager achievementManager;
    private HashSet<string> botonesClickeados = new HashSet<string>();
    private int totalBotonesDetalles = 8; // Cambia esto al número total de botones para "Amante de los detalles"
    private int totalBotonesNato = 3; // Cambia esto al número total de botones para "Nato1"

    // Método para registrar el clic en un botón
    public void BotonClickeado(string botonID)
    {
        if (!botonesClickeados.Contains(botonID))
        {
            botonesClickeados.Add(botonID);
            VerificarLogroDetalles();
            VerificarLogroNato();
        }
    }

    // Verificar si todos los botones han sido clickeados para "Amante de los detalles"
    private void VerificarLogroDetalles()
    {
        if (botonesClickeados.Count == totalBotonesDetalles)
        {
            achievementManager.UnlockAchievement("Amante de los detalles Caso 1");
            Debug.Log("Logro desbloqueado: Amante de los detalles Caso 1");
        }
    }

    // Verificar si todos los botones han sido clickeados para "Nato1"
    private void VerificarLogroNato()
    {
        if (botonesClickeados.Count == totalBotonesNato)
        {
            achievementManager.UnlockAchievement("Nato1");
            Debug.Log("Logro desbloqueado: Nato1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar más lógica aquí si es necesario
    }
}
