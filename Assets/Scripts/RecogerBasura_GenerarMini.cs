using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
/// <summary>
/// Script que sirve para que al colisionar con la basura esta se elimine
/// y se ingrese un nuevo miniBot a tus filas.
/// </summary>
public class RecogerBasura_GenerarMini : MonoBehaviour {

    #region "Atributos"

    public Transform miniBotPrefab;

    public static int Cuenta = 1;

    const float separacion = 0.8f;

    public DateTime TiempoUltimaActualizacion { get; set; }

    public GameObject ElTipo;

    public Toggle Dificultad;

    
    


    #endregion

    #region "Comportamientos"

    void Start()

    {

        Dificultad = this.gameObject.GetComponent<Toggle>();

        TiempoUltimaActualizacion = DateTime.Now;
    }
    

    /// <summary>
    /// Al colisionar una basura con /colisionado/ esta se destruira 
    /// y se generará un nuevo miniBot para RoboVacumm.
    /// </summary>
    /// <param name="colisionado">Objeto con el que se colisionó.</param>
    public void OnTriggerEnter2D(Collider2D colisionado)
    {
        if (colisionado.name == "PF_RoboVacumm")
        {
            Destroy(this.gameObject);
            if (DateTime.Now.Subtract(TiempoUltimaActualizacion) > TimeSpan.FromSeconds(0.12))
            {
                Transform cola = Snake.Padre.FindChild("MiniBot").transform;
                if (Snake.DireccionActual == Snake.TipoDireccion.Norte)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x, cola.transform.position.y - separacion, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Sur)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x, cola.transform.position.y + separacion, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Este)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x - separacion, cola.transform.position.y, 0), transform.rotation) as Transform;
                else if (Snake.DireccionActual == Snake.TipoDireccion.Oeste)
                    miniBotPrefab = Instantiate(miniBotPrefab, new Vector3(cola.transform.position.x + separacion, cola.transform.position.y, 0), transform.rotation) as Transform;

                ElTipo = miniBotPrefab.gameObject;
                ElTipo.transform.parent = Snake.Padre.transform;
                TiempoUltimaActualizacion = DateTime.Now;
                Cuenta++;
                Muerte.TiempoEspera = DateTime.Now;
            }
            var aleatorio=0;
            if (Application.loadedLevel == 2 || Application.loadedLevel == 4)
            {
                if (Facil.InteruptorDificultad.isOn)
                    aleatorio = UnityEngine.Random.Range(4,6);
                else if (Medio.InteruptorDificultad.isOn)
                    aleatorio = UnityEngine.Random.Range(2,2);
                else if (Dificil.InteruptorDificultad.isOn)
                    aleatorio = UnityEngine.Random.Range(1,1);


                ContraReloj.TiempoRestante += TimeSpan.FromSeconds(aleatorio);


            }
        }
    }

    #endregion

}
