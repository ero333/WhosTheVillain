using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    Scene nivelActual;
    // Start is called before the first frame update
    void Start()
    {
        nivelActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarEscena(int a)
    {
        SceneManager.LoadScene(a);
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SiguienteNivel();
    }
}
