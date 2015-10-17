using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Script que matá al jugador si sucede alguna de las situaciones de muerte.
/// </summary>
public class Muerte : MonoBehaviour {

    #region "Atributos"

    public static DateTime TiempoEspera { get; set; }

    public static DateTime HoraDefuncion { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {
        TiempoEspera = DateTime.Now;
    }

    /// <summary>
    /// Al colisionar una RoboVacumm con /colisionado/ esta se destruira,
    /// empezará la destrucción masiva de miniBots y se parará de generar basura.
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó.</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if ((colisionado.name == "PF_MiniBot(Clone)" || colisionado.name.Contains("Pared")) && DateTime.Now.Subtract(TiempoEspera) > TimeSpan.FromSeconds(1))
        {
            Destroy(this.gameObject);
            MiniBot.DestruccionMasiva = true;
            GeneradorBasura.PararGeneracion = true;
            HoraDefuncion = DateTime.Now;
        }
    }

    #endregion

}
