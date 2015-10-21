﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dificil : MonoBehaviour
{

    public enum TipoDificultad
    {
        Facil,
        Medio,
        Dificil
    }

    public static Toggle InteruptorDificultad { get; set; }
    public static TipoDificultad Dificultad { get; set; }
    // Use this for initialization
    void Start()
    {

        InteruptorDificultad = GameObject.FindGameObjectWithTag("Dificil").GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InteruptorDificultad.isOn)
            Dificultad = TipoDificultad.Dificil;

    }
}

