using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Clase que sirve para guardar las distintas direcciones que toma la RoboVacumm
/// en que momento fue y en que posición exacta para que así los miniBots tengan
/// una referencia para emular el trayecto de su lider.
/// </summary>
public class Direccionador : MonoBehaviour {

    #region "Atributos"

    public Snake.TipoDireccion Direccion { get; set; }

    public Vector3 Posiciones;

    public DateTime TiempoCreacion { get; set; }

    #endregion

    #region "Constructores"

    public Direccionador()
    {

    }

    public Direccionador(Snake.TipoDireccion direccion, Vector3 posiciones, DateTime tiempoCreacion)
    {
        Direccion = direccion;
        Posiciones = posiciones;
        TiempoCreacion = tiempoCreacion;
    }

    #endregion

}
