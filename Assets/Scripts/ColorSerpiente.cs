using UnityEngine;
using System.Collections;

public class ColorSerpiente : MonoBehaviour {

    public SpriteRenderer Sprite { get; set; }
    // Use this for initialization
    void Start ()
    {
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();

        if (SelectorColor.ColorEscogido == Color.clear)
            Sprite.color = Color.green;
        else
            Sprite.color = SelectorColor.ColorEscogido;
        
        if (Sprite.color == Color.green)
        {
            PowerScript.PosibilidadAcelerar = 3;
            PowerScript.PosibilidadCongelar = 6;
        }
        else
        {
            PowerScript.PosibilidadAcelerar = 2;
            PowerScript.PosibilidadCongelar = 6;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
