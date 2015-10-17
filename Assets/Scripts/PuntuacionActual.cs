using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script que sirve para calcular y mostrar la puntuación actual.
/// </summary>
public class PuntuacionActual : MonoBehaviour {

    #region "Atributos"
    public Text TextoPuntuacionActual { get; set; }
    public static int Puntuacion { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {
        Puntuacion = 0;
        RecogerBasura_GenerarMini.Cuenta = 1;
        TextoPuntuacionActual = this.gameObject.GetComponent<Text>();
        TextoPuntuacionActual.text = "PUNTAJE:\n" + Puntuacion;
    }
    
    void Update()
    {
        if ((RecogerBasura_GenerarMini.Cuenta - 1) * 125 > Puntuacion)
        {
            Puntuacion = (RecogerBasura_GenerarMini.Cuenta - 1) * 125;
            TextoPuntuacionActual.text = "PUNTAJE:\n" + Puntuacion;
        }
    }

    #endregion
}
