using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectorColor : MonoBehaviour {

    public Toggle Interuptor { get; set; }
    public static Color ColorEscogido { get; set; }
    // Use this for initialization
    void Start () {

        Interuptor = this.gameObject.GetComponent<Toggle>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Interuptor.isOn)
            ColorEscogido = Color.green;
        else
            ColorEscogido = Color.red;

    }
}
