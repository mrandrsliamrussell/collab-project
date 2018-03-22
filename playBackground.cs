using UnityEngine;
using System.Collections;

public class playBackground : MonoBehaviour {
    public MovieTexture background;
    public AudioSource music;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = background;
        background.Play();
        background.loop = true;
        music = GetComponent<AudioSource>();
        music.Play();
        music.loop = true;
    }
    void Update()
    {
        music.volume = titleScript.volumelvl;   //it is set to a reference, just that reference is in a different scene.
    }
	
	// Update is called once per frame
	
}
