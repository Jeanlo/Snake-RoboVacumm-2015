using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
/// <summary>
/// Script que sirve para guardar y/u obtener la puntuación maxima hecha por el usuario.
/// </summary>
public class PuntuacionMaxima : MonoBehaviour {
    #region "Atributos"

    public Text TextoPuntuacionMaxima { get; set; }
    public int Puntuacion { get; set; }

    #endregion

    #region "Comportamientos"

    void Start()
    {
        using (var fileStream = new FileStream("puntuacionMaxima.xml", FileMode.OpenOrCreate))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));

            try
            {
                var puntuacionCapturada = (int)serializer.ReadObject(fileStream);
                Puntuacion = puntuacionCapturada; //Se obtiene la puntuación maxima registrada.
            }
            catch
            {
                /*Si no existía antes el archivo, no habia puntuación maxima, 
                    se pone la Puntuacion en 0.*/            
                Puntuacion = 0; 
            }
        }

        TextoPuntuacionMaxima = gameObject.GetComponent<Text>();
        TextoPuntuacionMaxima.text = "PUNTAJE MAS ALTO:\n" + Puntuacion;
    }

    void Update()
    {
        if (PuntuacionActual.Puntuacion > Puntuacion)
        {
            Puntuacion = PuntuacionActual.Puntuacion;
            TextoPuntuacionMaxima.text = "PUNTAJE MAS ALTO:\n" + Puntuacion;
            XML_GuardarNuevaPuntuacionMaxima();
        }
    }

    /// <summary>
    /// Guarda la puntuación maxima.
    /// </summary>
    private void XML_GuardarNuevaPuntuacionMaxima()
    {
        using (var fileStream = new FileStream("puntuacionMaxima.xml", FileMode.Create))
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(int));
            serializer.WriteObject(fileStream, Puntuacion);
        }
    }

    #endregion

}
