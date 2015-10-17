﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
/// <summary>
/// Script que sirve para que al colisionar con la basura esta se elimine
/// y se ingrese un nuevo miniBot a tus filas.
/// </summary>
public class RecogerBasura_GenerarMini : MonoBehaviour {

    #region "Atributos"

    public Transform miniBotPrefab;

    public static int Cuenta = 1;

    const float separacion = 0.8f;

    public DateTime TiempoUltimaActualizacion { get; set; }

    public GameObject ElTipo;

    #endregion

    #region "Comportamientos"

    void Start()
    {
        TiempoUltimaActualizacion = DateTime.Now;
    }

    /// <summary>
    /// Al colisionar una basura con /colisionado/ esta se destruira 
    /// y se generará un nuevo miniBot para RoboVacumm.
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó.</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name == "PF_RoboVacumm")
        {
            Destroy(this.gameObject);
            if (DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
            {
                Transform cola = Snake.Padre.FindChild("MiniBot").transform;
                if (Snake.DireccionActual == Snake.TipoDireccion.Norte)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x, cola.transform.position.y - separacion, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Sur)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x, cola.transform.position.y + separacion, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Este)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x - separacion, cola.transform.position.y, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Oeste)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x + separacion, cola.transform.position.y, 0), transform.rotation) as Transform;

                ElTipo = miniBotPrefab.gameObject;
                ElTipo.transform.parent = Snake.Padre.transform;
                TiempoUltimaActualizacion = DateTime.Now;
                Cuenta++;
                Muerte.TiempoEspera = DateTime.Now;
            }

            if (Application.loadedLevel == 3)
            {
                var aleatorio = UnityEngine.Random.Range(2, 4);
                ContraReloj.TiempoRestante += TimeSpan.FromSeconds(aleatorio);
            }
        }
    }

    #endregion

}
