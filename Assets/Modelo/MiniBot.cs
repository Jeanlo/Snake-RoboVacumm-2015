using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
/// <summary>
/// Clase que sostiene el modelo de los miniBots.
/// </summary>
public class MiniBot : MonoBehaviour {

    #region "Atributos"

    public static List<Direccionador> Direcciones = new List<Direccionador>();

    public Snake.TipoDireccion DireccionActual { get; set; }

    public static Vector3 Velocidad { get; set; }

    public static Vector3 Aceleracion = new Vector3(1f, 1f, 0);

    public DateTime TiempoUltimaActualizacion { get; set; }

    public DateTime TiempoCreacion { get; set; }

    public int UltimoDireccionadorIdentificado { get; set; }

    public static bool DestruccionMasiva { get; set; }

    #endregion

}
