using UnityEngine;
using System.Collections;

public class CameraOffset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Translate(0, 0, -(gridScript.globalArrayLength - 6) * 5); //zooms out for the bigger game grids
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
