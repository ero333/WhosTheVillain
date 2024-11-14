using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesbloqueoDeNiveles : MonoBehaviour
{
    public int NivelesDesbloqueados;
    public Button[] BotonesNiveles;
    private Dictionary<int, string> levelScenes = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeLevelScenes();

        foreach (Button Boton in BotonesNiveles)
        {
            Boton.interactable = false;
        }

        NivelesDesbloqueados = PlayerPrefs.GetInt("Niveles Ganados", 0); // Asegurar un valor por defecto

        for (int i = 0; i <= NivelesDesbloqueados && i < BotonesNiveles.Length; i++)
        {
            BotonesNiveles[i].interactable = true;
            int index = i;  // Necesario para el closure en el callback
            BotonesNiveles[i].onClick.AddListener(() => SeleccionarNivel(index));
        }
    }

    void SeleccionarNivel(int nivelIndex)
    {
        PlayerPrefs.SetInt("CurrentLevel", nivelIndex + 1);
        SceneManager.LoadScene(levelScenes[nivelIndex + 1]);
    }

    void InitializeLevelScenes()
    {
        levelScenes.Add(1, "Cutscene Intro Detective");
        levelScenes.Add(2, "Cutscene intro villano");
        levelScenes.Add(3, "Cutscene Intro Detective N2");
        levelScenes.Add(4, "Cutscene intro villano2");
        levelScenes.Add(5, "Cutscene Intro Detective 3");
        levelScenes.Add(6, "Cutscene Intro Villano 3");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DesbloquearTodosLosNiveles()
    {
        foreach (Button Boton in BotonesNiveles)
        {
            Boton.interactable = true;
        }

        PlayerPrefs.SetInt("Niveles Ganados", BotonesNiveles.Length - 1);
        PlayerPrefs.Save();
    }
}
