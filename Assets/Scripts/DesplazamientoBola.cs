using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class DesplazamientoBola : MonoBehaviour
{
    public DateTime TiempoCreacion { get; set; }
    public enum TipoBola
    {
        Movedora,
        Rebotadora_Movedora
    }

    public enum TipoDireccionX
    {
        Este,
        Oeste
    }

    public enum TipoDireccionY
    {
        Norte,
        Sur
    }

    public TipoBola TipoActual { get; set; }

    public TipoDireccionX DireccionActualX { get; set; }
    public TipoDireccionY DireccionActualY { get; set; }

    public Vector3 Velocidad { get; set; }
    public int contador=0;

    public DateTime TiempoUltimaActualizacion { get; set; }
    public DateTime Tiempo { get; set; }
    public DateTime Tiempo1 { get; set; }
    public static DateTime TiempoAturdimiento { get; set; }

    // Use this for initialization
    void Awake()
    {
        DireccionActualX = TipoDireccionX.Este;
        DireccionActualY = TipoDireccionY.Sur;

        var aletoriorioX = UnityEngine.Random.Range(0.059f, 1f);
        var aletoriotorioY = UnityEngine.Random.Range(-1f, -0.059f);
        var aletoriotorioC = UnityEngine.Random.Range(0.2f, 0.4f);
        Velocidad = new Vector3(aletoriorioX, aletoriotorioY);

        TiempoUltimaActualizacion = DateTime.Now;
        TiempoCreacion = DateTime.Now;
        Tiempo = DateTime.Now;
        Tiempo1 = DateTime.Now; 
    }

    void Update()
    {
        if (DateTime.Now.Subtract(TiempoCreacion) > TimeSpan.FromSeconds(25))
            Destroy(this.gameObject);

        Desplazarse();
        if(DateTime.Now - Tiempo >= TimeSpan.FromSeconds(0.5) && DireccionActualY==TipoDireccionY.Norte)   
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.01f;

        }
        if (DateTime.Now - Tiempo1 >= TimeSpan.FromSeconds(0.5) && DireccionActualY == TipoDireccionY.Sur)
        {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.01f;
        }

        if (Snake.Protegido)
            GenerarGuantes.PosicionPelota = this.transform.localPosition;

    }

    public void Desplazarse()
    {
        while (DireccionActualX == TipoDireccionX.Este && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.03))
        {
            transform.Translate(Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }

        while (DireccionActualX == TipoDireccionX.Oeste && DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.03))
        {
            transform.Translate(-Velocidad.x, 0, 0);
            TiempoUltimaActualizacion = DateTime.Now;
        }
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name.Contains("ParedEste") || colisionado.name.Contains("ParedOeste"))
        {
            if (DireccionActualX == TipoDireccionX.Este)
                DireccionActualX = TipoDireccionX.Oeste;
            else if (DireccionActualX == TipoDireccionX.Oeste)
                DireccionActualX = TipoDireccionX.Este;
        }
        if (colisionado.name.Contains("ParedNorte") || colisionado.name.Contains("ParedSur"))
        {
            
            if (DireccionActualY == TipoDireccionY.Norte)
            {
                DireccionActualY = TipoDireccionY.Sur;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
                Tiempo1 = DateTime.Now;
            }
            else if (DireccionActualY == TipoDireccionY.Sur)
            {
                DireccionActualY = TipoDireccionY.Norte;
                    this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.5f;
                Tiempo = DateTime.Now;
            }
        }

        if (colisionado.name == "PF_RoboVacumm")
        {
            if (Snake.DireccionActual != Snake.TipoDireccion.Reposo)
                Snake.DireccionAntesAturdimiento = Snake.DireccionActual;
            Snake.Aturdido = true;
            Snake.DireccionActual = Snake.TipoDireccion.Reposo;
            PuntuacionActual.Puntuacion -= 250;
            TiempoAturdimiento = DateTime.Now;
        }

        if (colisionado.name == "PF_MiniBot(Clone)")
        {
            Destroy(colisionado.gameObject);
            PuntuacionActual.Puntuacion -= 50;
        }
    }
}




