using UnityEngine;
using System.Collections;

public class ColorMiniBots : MonoBehaviour
{
    public SpriteRenderer Sprite { get; set; }

    // Use this for initialization
    void Start ()
    {
        Sprite = this.gameObject.GetComponent<SpriteRenderer>();
        if (SelectorColor.ColorEscogido == Color.clear)
            Sprite.color = Color.green;
        else
            Sprite.color = SelectorColor.ColorEscogido;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
