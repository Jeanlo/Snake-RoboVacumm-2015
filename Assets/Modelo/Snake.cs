using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/// <summary>
/// Clase que sostiene el modelo de la RoboVacumm.
/// </summary>
public class Snake : MonoBehaviour {

    #region "Enums"

    public enum TipoDireccion
    {
        Reposo,
        Norte,
        Sur,
        Este,
        Oeste
    }

    #endregion

    #region "Atributos"
    public static Transform Padre;
    public Vector3 Velocidad { get; set; }

    public static Vector3 Aceleracion = new Vector3(1f, 1f, 0);

    public static TipoDireccion DireccionActual { get; set; }

    public DateTime TiempoUltimaActualizacion { get; set; }

    public DateTime UltimaCapturaDeTeclado { get; set; }

    public static TimeSpan TiempoCambio { get; set; }
    public float XAcelerado { get; set; }
    public float YAcelerado { get; set; }

    #endregion

    #region "Comportamientos"

    /// <summary>
    /// Mantiene el desplazamiento hacia la direccion actual.
    /// </summary>
    public void Desplazarse()
    {
        while (DireccionActual == TipoDireccion.Norte && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            if (TiempoCambio > TimeSpan.FromSeconds(0))
            {
                CambioVelocidad();
                TiempoCambio -= TimeSpan.FromSeconds(0.5);
            }
            else
            {
                Velocidad = new Vector3(0.4f, 0.4f);
            }
            CambioPosicion();
            transform.Translate(0, Velocidad.y, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }

        while (DireccionActual == TipoDireccion.Sur && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            if (TiempoCambio > TimeSpan.FromSeconds(0))
            {
                CambioVelocidad();
                TiempoCambio -= TimeSpan.FromSeconds(0.5);
            }
            else
            {
                Velocidad = new Vector3(0.4f, 0.4f);
            }
            CambioPosicion();
            transform.Translate(0, -Velocidad.y, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }

        while (DireccionActual == TipoDireccion.Este && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            if (TiempoCambio > TimeSpan.FromSeconds(0))
            {
                CambioVelocidad();
                TiempoCambio -= TimeSpan.FromSeconds(0.5);
            }
            else
            {
                Velocidad = new Vector3(0.4f, 0.4f);
            }
            CambioPosicion();
            transform.Translate(Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }

        while (DireccionActual == TipoDireccion.Oeste && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
        {
            if (TiempoCambio > TimeSpan.FromSeconds(0))
            {
                CambioVelocidad();
                TiempoCambio -= TimeSpan.FromSeconds(0.5);
            }
            else
            {
                Velocidad = new Vector3(0.4f, 0.4f);
            }
            CambioPosicion();
            transform.Translate(-Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }

    /// <summary>
    /// Lee una direccion y hace que la serpiente se comience a dirigir a esta.
    /// </summary>
    public void EmpezarDesplazarse()
    {
        if (Input.GetKey(KeyCode.None))
            return;

        if(DateTime.Now.Subtract(UltimaCapturaDeTeclado) > TimeSpan.FromSeconds(0.12))
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                UltimaCapturaDeTeclado = DateTime.Now;
                DireccionActual = TipoDireccion.Norte;
                MiniBot.Direcciones.Add(new Direccionador(TipoDireccion.Norte, transform.position, DateTime.Now));                
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                UltimaCapturaDeTeclado = DateTime.Now;
                DireccionActual = TipoDireccion.Sur;
                MiniBot.Direcciones.Add(new Direccionador(TipoDireccion.Sur, transform.position, DateTime.Now));
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                UltimaCapturaDeTeclado = DateTime.Now;
                DireccionActual = TipoDireccion.Este;
                MiniBot.Direcciones.Add(new Direccionador(TipoDireccion.Este, transform.position, DateTime.Now));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                UltimaCapturaDeTeclado = DateTime.Now;
                DireccionActual = TipoDireccion.Oeste;
                MiniBot.Direcciones.Add(new Direccionador(TipoDireccion.Oeste, transform.position, DateTime.Now));
            }
        }        
    }

    public void CambioVelocidad()
    {
        XAcelerado = Velocidad.x * Aceleracion.x;
        YAcelerado = Velocidad.y * Aceleracion.y;
        Velocidad = new Vector3(XAcelerado, YAcelerado, 0);        
        MiniBot.Velocidad = new Vector3(XAcelerado, YAcelerado, 0);
    }

    public void CambioPosicion()
    {
        for(int i = Padre.childCount - 1; i > 0; i--)
        {
            Padre.GetChild(i).position = Padre.GetChild(i - 1).position;
        }
    }

    #endregion

}
