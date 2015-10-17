using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script para reproducir el sonido de GameOver.
/// </summary>
public class SonidoGameOver : MonoBehaviour
{
    #region "Atributos"

    public AudioSource SonidoMuerte { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {
        SonidoMuerte = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GeneradorBasura.PararGeneracion == true)
        {
            SonidoMuerte.mute = false;
            SonidoMuerte.Play();
        }
    }

    #endregion

}
