using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ContraReloj : MonoBehaviour {
    public static DateTime TiempoRestante { get; set; }
    public DateTime UltimaActualizacion { get; set; }
    public Text TextoReloj { get; set; }

    void Start () {
        UltimaActualizacion = DateTime.Now;
        TiempoRestante = new DateTime();
        TiempoRestante += TimeSpan.FromSeconds(30);
        TextoReloj = gameObject.GetComponent<Text>();
        TextoReloj.text = TiempoRestante.Second.ToString() + "s";
    }
	
	void Update () {
        if(TiempoRestante.Second <= 0)
        {
            GeneradorBasura.PararGeneracion = true;
            MiniBot.DestruccionMasiva = true;
            return;
        }
        ContarTiempo();
    }

    void ContarTiempo()
    {
        if(DateTime.Now.Subtract(UltimaActualizacion) > TimeSpan.FromSeconds(1.12))
        {
            TiempoRestante -= TimeSpan.FromSeconds(1);
            UltimaActualizacion = DateTime.Now;
            TextoReloj.text = TiempoRestante.Second.ToString() + "s";
        }
    }
}
