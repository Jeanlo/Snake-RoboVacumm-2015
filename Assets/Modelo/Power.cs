using UnityEngine;
using System.Collections;
using System;

public class Power : MonoBehaviour {

    #region "Enums"

    public enum TipoPower
    {
        Aceleracion, //Bateria
        Proteccion, //Guante
        CongelarBasura, //Aire acondicionado
        Desacelerar, //Descarga electrica
        Quemar //Fuego
    }

    #endregion

    #region "Atributos"

    public TipoPower PowerActual { get; set; }

    #endregion

    #region "Comportamientos"

    public void Acelerar()
    {
        Snake.Aceleracion = new Vector3(1.09f, 1.09f, 0);
        MiniBot.Aceleracion = new Vector3(1.09f, 1.09f, 0);
    }

    public void Desacelerar()
    {
        Snake.Aceleracion = new Vector3(0.9f, 0.9f, 0);
        MiniBot.Aceleracion = new Vector3(0.9f, 0.9f, 0);
    }

    public void ActivarAireAcondicionado()
    {
        DesplazamientoBasura.TiempoDestruccion = TimeSpan.FromSeconds(8);
    }

    public void Quemar()
    {
        var aleatorioDireccion = UnityEngine.Random.Range(0, 2);
        if (aleatorioDireccion == 0)
        {
            if (Snake.DireccionActual == Snake.TipoDireccion.Norte || Snake.DireccionActual == Snake.TipoDireccion.Sur)
                Snake.DireccionActual = Snake.TipoDireccion.Este;
            else
                Snake.DireccionActual = Snake.TipoDireccion.Norte;
        }

        if (aleatorioDireccion == 1)
        {
            if (Snake.DireccionActual == Snake.TipoDireccion.Norte || Snake.DireccionActual == Snake.TipoDireccion.Sur)
                Snake.DireccionActual = Snake.TipoDireccion.Oeste;
            else
                Snake.DireccionActual = Snake.TipoDireccion.Sur;
        }
    }

    #endregion
}
