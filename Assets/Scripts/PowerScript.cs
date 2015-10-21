using UnityEngine;
using System.Collections;
using System;

public class PowerScript : Power
{
    public SpriteRenderer Sprite { get; set; }
    public static int PosibilidadAcelerar { get; set; }
    public static int PosibilidadCongelar { get; set; }


    void Awake()
    {
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
        var aleatorio = UnityEngine.Random.Range(0, 10);
        if(aleatorio > 0 && aleatorio <= PosibilidadAcelerar)
        {
            PowerActual = TipoPower.Aceleracion;
            Sprite.color = Color.green;
        }
        else  if (aleatorio > PosibilidadAcelerar && aleatorio <= PosibilidadCongelar)
        {
            PowerActual = TipoPower.CongelarBasura;
            Sprite.color = Color.blue;
        }
        else if (aleatorio > PosibilidadCongelar && aleatorio <= 7)
        {
            PowerActual = TipoPower.Proteccion;
            Sprite.color = Color.gray;
        }
        else if (aleatorio == 8)
        {
            PowerActual = TipoPower.Desacelerar;
            Sprite.color = Color.red;
        }
        else
        {
            PowerActual = TipoPower.Quemar;
            Sprite.color = Color.yellow;
        }
    }

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name == "PF_RoboVacumm")
        {
            if(PowerActual == TipoPower.Aceleracion)
                Acelerar();
            if (PowerActual == TipoPower.Desacelerar)
                Desacelerar();
            if (PowerActual == TipoPower.CongelarBasura)
                ActivarAireAcondicionado();
            if (PowerActual == TipoPower.Quemar)            
                Quemar();
            if (PowerActual == TipoPower.Proteccion)
                Snake.Protegido = true;

            Destroy(this.gameObject);
            Snake.TiempoCambio = TimeSpan.FromSeconds(2);
        }
    }
}
