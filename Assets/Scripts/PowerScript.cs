using UnityEngine;
using System.Collections;
using System;

public class PowerScript : Power
{
    public SpriteRenderer Sprite { get; set; }


    void Awake()
    {
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
        var aleatorio = UnityEngine.Random.Range(0, 4);
        if(aleatorio == 0)
        {
            PowerActual = TipoPower.Aceleracion;
            Sprite.color = Color.green;
        }

        if(aleatorio == 1)
        {
            PowerActual = TipoPower.Desacelerar;
            Sprite.color = Color.red;
        }

        if(aleatorio == 2)
        {
            PowerActual = TipoPower.CongelarBasura;
            Sprite.color = Color.blue;
        }

        if (aleatorio == 3)
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

                Destroy(this.gameObject);
            Snake.TiempoCambio = TimeSpan.FromSeconds(2);
        }
    }
}
