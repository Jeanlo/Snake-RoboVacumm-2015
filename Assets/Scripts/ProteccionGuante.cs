using UnityEngine;
using System.Collections;
using System;

public class ProteccionGuante : MonoBehaviour {
    public DateTime TiempoAtrapada { get; set; }
                                       // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Snake.Protegido)
            return;

	    if(DateTime.Now.Subtract(TiempoAtrapada) > TimeSpan.FromSeconds(0.5))
            Destroy(this.gameObject);
	}

    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name == "PF_Pelota(Clone)")
        {
            Destroy(colisionado.gameObject);
            Snake.Protegido = false;
            TiempoAtrapada = DateTime.Now;
        }
    }
}
