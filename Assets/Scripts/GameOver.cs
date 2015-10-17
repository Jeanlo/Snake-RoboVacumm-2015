using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
/// <summary>
/// Script que al cumplirse las condiciones de GameOver muestra la imagen de ello
/// y termina la partida.
/// </summary>
public class GameOver : MonoBehaviour {

    #region "Atributos"
    public Image ImagenGameOver { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {

        ImagenGameOver = this.gameObject.GetComponent<Image>();
        ImagenGameOver.enabled = false;
    }

    void Update()
    {
        if (GeneradorBasura.PararGeneracion == true)
        {
            ImagenGameOver.enabled = true;
            if (DateTime.Now.Subtract(Muerte.HoraDefuncion) > TimeSpan.FromSeconds(1))
            {
                Application.LoadLevel(0);
            }
        }
    }

    #endregion

}
