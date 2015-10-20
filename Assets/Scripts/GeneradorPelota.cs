using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Script que a partir de un Prefab genera la basura.
/// </summary>
public class GeneradorPelota : MonoBehaviour
{

    #region "Atributos"

    public DateTime TiempoUltimaGeneracion { get; set; }
    public Transform PelotaPrefab;
    public static bool PararGeneracion { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {
        PararGeneracion = false;
        TiempoUltimaGeneracion = DateTime.Now;

    }

    void Update()
    {
        var Tiempo = UnityEngine.Random.Range(10,30);
        if (DateTime.Now.Subtract(TiempoUltimaGeneracion) > TimeSpan.FromSeconds(Tiempo) && !PararGeneracion)
        {
            Instantiate(PelotaPrefab, new Vector3(-8f, 4, 0), transform.rotation);
            TiempoUltimaGeneracion = DateTime.Now;
        }
    }

    #endregion

}
