using UnityEngine;
using System.Collections;
using System;

public class Power : MonoBehaviour {

    #region "Enums"

    public enum TipoPower
    {
        Aceleracion, //Bateria - Hecho
        Proteccion, //Guante
        CongelarBasura, //Aire acondicionado
        Desacelerar, //Descarga electrica - Hecho
        Quemar, //Fuego
        Aturdir //Pelota beisbol
    }

    #endregion

    #region "Atributos"

    public TipoPower PowerActual { get; set; }    

    #endregion

    #region "Comportamientos"

    public void Acelerar()
    {
        Snake.Aceleracion = new Vector3(1.05f, 1.05f, 0);
        MiniBot.Aceleracion = new Vector3(1.05f, 1.05f, 0);
    }

    public void Desacelerar()
    {
        Snake.Aceleracion = new Vector3(0.5f, 0.5f, 0);
        MiniBot.Aceleracion = new Vector3(0.5f, 0.5f, 0);
    }

    public void ActivarAireAcondicionado()
    {
        DesplazamientoBasura.TiempoDestruccion = TimeSpan.FromSeconds(8);
    }

    #endregion
}
