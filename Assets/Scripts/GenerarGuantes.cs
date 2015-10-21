using UnityEngine;
using System.Collections;

public class GenerarGuantes : MonoBehaviour {
    public static Vector3 PosicionPelota = Vector3.zero;
    public Transform GuantePrefab;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Snake.Protegido && PosicionPelota != Vector3.zero)
        {
            Instantiate(GuantePrefab, new Vector3(PosicionPelota.x, PosicionPelota.y, 0), transform.rotation);
        }
	}
}
