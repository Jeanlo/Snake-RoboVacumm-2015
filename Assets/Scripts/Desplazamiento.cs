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
        {
            if (Aturdido)
            {
                VolverDesplazarse();
            }
            else
            {
                EmpezarDesplazarse();
            }

        }
        else
        {
            Desplazarse();
            EmpezarDesplazarse();
        }
    }

    void VolverDesplazarse()
    {
        if (DateTime.Now.Subtract(DesplazamientoBola.TiempoAturdimiento) > TimeSpan.FromSeconds(0.8))
        {
            DireccionActual = DireccionAntesAturdimiento;
            Aturdido = false;
            Desplazarse();
        }
    }

    #endregion

}
