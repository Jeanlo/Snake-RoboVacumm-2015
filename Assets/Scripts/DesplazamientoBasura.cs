using UnityEngine;
using System.Collections;
using System;

public class DesplazamientoBasura : MonoBehaviour {

    public static TimeSpan TiempoDestruccion { get; set; }
    public DateTime UltimaActualizacion { get; set; }
	
    void Start()
    {
        UltimaActualizacion = DateTime.Now;
    }

	// Update is called once per frame
	void Update () {
        if(Application.loadedLevel == 4 || Application.loadedLevel == 5)
        {
            if (DateTime.Now.Subtract(UltimaActualizacion) > TimeSpan.FromSeconds(1))
            {
                TiempoDestruccion -= TimeSpan.FromSeconds(1);
                UltimaActualizacion = DateTime.Now;
            }

            if (TiempoDestruccion <= TimeSpan.FromSeconds(0))
            {
                Destroy(this.gameObject);
            }
        }
	}
}
