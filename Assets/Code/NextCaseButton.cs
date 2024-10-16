using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCaseButton : MonoBehaviour
{
    public Button nextCaseButton;

    void Start()
    {
        nextCaseButton.onClick.AddListener(LoadNextCase);
    }

    void LoadNextCase()
    {
        GuardarDatos.Instancia.LoadNextCase();
    }
}
