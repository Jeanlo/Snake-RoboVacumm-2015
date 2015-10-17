using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivarMenuInGame : MonoBehaviour {

    public Button Boton { get; set; }    

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        Boton = this.gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Boton.interactable == false)
            {
                Boton.interactable = true;
                Cursor.visible = true;
            }
            else
            {
                Boton.interactable = false;
                Cursor.visible = false;
            }
        }
	}
}
