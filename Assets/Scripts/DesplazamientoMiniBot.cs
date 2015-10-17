using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/// <summary>
/// Script que sirve para llamar a las funciones de desplazamiento de los miniBots
/// y inicializar a estos.
/// </summary>
public class DesplazamientoMiniBot : MiniBot
{
    #region "Comportamientos"

    void Start()
    {
        DestruccionMasiva = false;
    }

    void Update()
    {
        //Si la RoboVacumm ha muerto, cada miniBot se autodestruirá.
        if (DestruccionMasiva == true)
            Destroy(this.gameObject);
    }

    void Awake()
    {
        DireccionActual = Snake.DireccionActual;
        Velocidad = new Vector3(0.4f, 0.4f);
        TiempoUltimaActualizacion = DateTime.Now;
        TiempoCreacion = DateTime.Now;
    }

    #endregion


}
