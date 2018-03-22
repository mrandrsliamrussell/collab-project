using UnityEngine;
using System.Collections;

public class lightScript : MonoBehaviour {
    public static bool destroy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (destroy == true)
        {
            Destroy(gameObject);
        }
    }
}
