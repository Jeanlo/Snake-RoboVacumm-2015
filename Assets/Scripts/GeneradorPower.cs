using UnityEngine;
using System.Collections;
using System;

public class GeneradorPower : MonoBehaviour {

    public DateTime TiempoUltimaGeneracion { get; set; }
    public Transform PowerPrefab;
    public static bool PararGeneracion { get; set; }
    // Use this for initialization
    void Start () {

        PararGeneracion = false;
        TiempoUltimaGeneracion = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
        if (DateTime.Now.Subtract(TiempoUltimaGeneracion) > TimeSpan.FromSeconds(9) && !PararGeneracion)
        {
            var aleatorioX = UnityEngine.Random.Range(0, 6.5f);
            var aleatorioY = UnityEngine.Random.Range(0, 3f);
            var aleatorioS = UnityEngine.Random.Range(0, 1);
            if (aleatorioS == 0)
                aleatorioX *= -1;
            else
                aleatorioY *= -1;
            Instantiate(PowerPrefab, new Vector3(aleatorioX, aleatorioY, 0), transform.rotation);
            TiempoUltimaGeneracion = DateTime.Now;
        }
    }
}
