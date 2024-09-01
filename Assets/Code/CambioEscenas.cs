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

    public void Selector()
    {
        SceneManager.LoadScene("Selector de niveles");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SiguienteNivel();
    }
}
