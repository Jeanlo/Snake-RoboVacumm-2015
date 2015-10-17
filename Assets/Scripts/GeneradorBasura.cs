using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Script que a partir de un Prefab genera la basura.
/// </summary>
public class GeneradorBasura : MonoBehaviour {

    #region "Atributos"

    public DateTime TiempoUltimaGeneracion { get; set; }
    public Transform BasuraPrefab;
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
        if (DateTime.Now.Subtract(TiempoUltimaGeneracion) > TimeSpan.FromSeconds(3) && !PararGeneracion)
        {
            var aleatorioX = UnityEngine.Random.Range(0, 6.5f);
            var aleatorioY = UnityEngine.Random.Range(0, 3f);
            var aleatorioS = UnityEngine.Random.Range(0, 1);
            if (aleatorioS == 0)
                aleatorioX *= -1;
            else
                aleatorioY *= -1;
            Instantiate(BasuraPrefab, new Vector3(aleatorioX, aleatorioY, 0), transform.rotation);
            TiempoUltimaGeneracion = DateTime.Now;
            if(DesplazamientoBasura.TiempoDestruccion <= TimeSpan.FromSeconds(2))
                DesplazamientoBasura.TiempoDestruccion = TimeSpan.FromSeconds(2);
        }
    }

    #endregion

}
