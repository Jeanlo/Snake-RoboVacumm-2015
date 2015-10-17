using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Script que sirve para llamar a las funciones de desplazamiento de Snake
/// e inicializar al RoboVacumm.
/// </summary>
public class Desplazamiento : Snake {

    #region "Comportamientos"

    void Start()
    {
        Padre = transform.parent;
        Velocidad = new Vector3(0.4f, 0.4f);
        TiempoUltimaActualizacion = DateTime.Now;
        DireccionActual = TipoDireccion.Reposo;
    }

    void Update()
    {
        if (DireccionActual == TipoDireccion.Reposo)
            EmpezarDesplazarse();
        else
        {
            Desplazarse();
            EmpezarDesplazarse();
        }
    }

    #endregion

}
