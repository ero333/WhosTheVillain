using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public string levelName;
    public string initialSceneName;
    public bool isInitialScene;
    public string numberLevel;
    Scene nivelActual;
    // Start is called before the first frame update
    void Start()
    {
        nivelActual = SceneManager.GetActiveScene();

        if (GameManager.instance == null)
        {
            // Crear el GameManager si no existe
            GameObject gameManager = new GameObject("GameManager");
            gameManager.AddComponent<GameManager>();
            Debug.Log("GameManager creado en la escena: " + SceneManager.GetActiveScene().name);
        }

        if (isInitialScene && !string.IsNullOrEmpty(initialSceneName))
        {
            Debug.Log("Configurando escena inicial: " + initialSceneName + " para el nivel: " + levelName);
            GameManager.instance.SetInitialScene(levelName, initialSceneName);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene Intro Detective")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene Intro Detective N2")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene Intro Detective 3")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene intro villano")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene intro villano2")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Cutscene Intro Villano 3")
        {
            Debug.Log("LevelStart: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Pantalla Derrota")
        {
            Debug.Log("GameOver: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Pantalla Derrota Villano")
        {
            Debug.Log("GameOver: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Pantalla Derrota Villano Interrogatorio")
        {
            Debug.Log("GameOver: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Pantalla Victoria Villano")
        {
            Debug.Log("LevelComplete: " + SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().name == "Pantalla Victoria")
        {
            Debug.Log("LevelComplete: " + SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarEscena(int a)
    {
        SceneManager.LoadScene(a);
   
    }

    public void EventoSk�p(int a)
    {
        SceneManager.LoadScene(a);
        Debug.Log("Skip");
    }

    public void SiguienteNivel()
    {
        SceneManager.LoadScene(nivelActual.buildIndex + 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Selector()
    {
        SceneManager.LoadScene("Selector de niveles");
    }

    public void DNivel1()
    {
        SceneManager.LoadScene("Nivel 1 Oficina");
    }

    public void DNivel2()
    {
        SceneManager.LoadScene("Nivel 2 Oficina D");
    }

    public void DNivel3()
    {
        SceneManager.LoadScene("Nivel 3 Oficina D");
    }

    public void CineV1()
    {
        SceneManager.LoadScene("Cutscene intro villano");
    }


    public void VNivel1()
    {
        SceneManager.LoadScene("Nivel 1 villano");
    }

    public void CineV2()
    {
        SceneManager.LoadScene("Cutscene intro villano2");
    }

    public void VNivel2()
    {
        SceneManager.LoadScene("Nivel 2 villano");
    }

    public void VNivel3()
    {
        SceneManager.LoadScene("Nivel 3 villano");
    }

    public void LogrosDetective()
    {
        SceneManager.LoadScene("Logros Detective");
    }

    public void LogrosVillano()
    {
        SceneManager.LoadScene("Logros Villano");
    }

    public void PantallaDerrotaVillano()
    {
        SceneManager.LoadScene("Pantalla Derrota Villano");
    }

    public void VNivel1pt2()
    {
        SceneManager.LoadScene("Nivel 1 Villano pt2");
    }

    public void VNivel1Interrogatorio()
    {
        SceneManager.LoadScene("Nivel 1 Villano Interrogatorio");
    }

    public void PantallaDerrotaDetective()
    {
        SceneManager.LoadScene("Pantalla Derrota");
    }

    public void PantallaVictoriaDetective()
    {
        SceneManager.LoadScene("Pantalla Victoria");
    }

    public void CutsceneDerrotaDetective()
    {
        SceneManager.LoadScene("Cutscene Derrota D");
    }

    public void C1D ()
    {
        SceneManager.LoadScene("Cutscene Intro Detective");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SiguienteNivel();
    }
}