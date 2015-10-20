using UnityEngine;
using System.Collections;
/// <summary>
/// Script que controla el cambio entre pantallas y el menu principal.
/// </summary>
public class MenuPrincipal : MonoBehaviour
{
    #region "Comportamientos"

    void Start()
    {
        if (Application.loadedLevel == 0)
            Cursor.visible = true;
    }

    /// <summary>
    /// A traves de /opcion/ que comportamiento se hará o que nivel se cargará.
    /// </summary>
    /// <param name="opcion">Opcion escogida.</param>
    public void SeleccionMenuPrincipal(string opcion)
    {
        switch (opcion)
        {
            case "Clasico":
                Application.LoadLevel(1);
                break;
            case "Extremo":
                Application.LoadLevel(4);
                break;
            case "Creditos":
                Application.LoadLevel(2);
                break;
            case "Contrareloj":
                Application.LoadLevel(3);
                break;
            case "Power":
                Application.LoadLevel(5);
                break;
            case "Musica":
                if (AudioListener.volume > 0)
                    AudioListener.volume = 0;
                else
                    AudioListener.volume = 1;
                break;
            case "Salir":
                Application.Quit();
                break;
            case "Inicio":
                Application.LoadLevel(0);
                break;
        }
    }

    #endregion

}
