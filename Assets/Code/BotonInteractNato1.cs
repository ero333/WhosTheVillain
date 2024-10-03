using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInteractuableNato1 : MonoBehaviour
{
    public Desbloqueador desbloqueador;
    public string botonID;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        desbloqueador.BotonClickeado(botonID);
    }
}
