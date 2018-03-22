using UnityEngine;
using System.Collections;

public class Cubevar : MonoBehaviour {

    public int xpos;
    public int ypos;
    public int zpos;
    GameObject selection1;
    GameObject selection2;
    GameObject selectionHold;
    [SerializeField]
    public GameObject highlight;
    public Light Newlight;
    gridScript GameController;
    AudioClip swapnoise;
    AudioSource music;
    int selectionCounter;
    int[,,] colour = new int[gridScript.globalArrayLength, gridScript.globalArrayLength, gridScript.globalArrayLength];
    // Use this for initialization
    void Start() {
        music = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update ()
    {
        //selecting cubes to swap
        if (Input.GetMouseButtonDown(0))
        {
            lightScript.destroy = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f));
            {
                try {
                    if (selectionCounter == 0) //holds instance of first cube
                    {
                        
                        selection1 = hit.collider.gameObject;
                        
                        selectionHold = hit.collider.gameObject;
                        selectionCounter = 1;
                        lightScript.destroy = false;
                     highlight = Instantiate(Newlight, new Vector3(selection1.GetComponent<Cubevar>().xpos * 7, selection1.GetComponent<Cubevar>().ypos * 7, selection1.GetComponent<Cubevar>().zpos * 7), Quaternion.identity) as GameObject;
                    }
                    else if (selectionCounter == 1) // holds instance of second cube
                    {
                        selection2 = hit.collider.gameObject;
                        //swapping cubes

                        if (selection1.GetComponent<Cubevar>().xpos == selection2.GetComponent<Cubevar>().xpos - 1 ^  // ^ = xor to stop diagonal selection
                           selection1.GetComponent<Cubevar>().xpos == selection2.GetComponent<Cubevar>().xpos + 1 ^
                           selection1.GetComponent<Cubevar>().ypos == selection2.GetComponent<Cubevar>().ypos - 1 ^ //check if selections are adjacent to each other 
                           selection1.GetComponent<Cubevar>().ypos == selection2.GetComponent<Cubevar>().ypos + 1 ^
                           selection1.GetComponent<Cubevar>().zpos == selection2.GetComponent<Cubevar>().zpos - 1 ^
                           selection1.GetComponent<Cubevar>().zpos == selection2.GetComponent<Cubevar>().zpos + 1)
                        {
                            GameController = GameObject.FindObjectOfType(typeof(gridScript)) as gridScript;    //switches cubes 2 = 1, 3 = 2, 1 = 3
                            colour[selectionHold.GetComponent<Cubevar>().xpos, selectionHold.GetComponent<Cubevar>().ypos, selectionHold.GetComponent<Cubevar>().zpos] =
                            GameController.grid[selection1.GetComponent<Cubevar>().xpos, selection1.GetComponent<Cubevar>().ypos, selection1.GetComponent<Cubevar>().zpos];

                            GameController.grid[selection1.GetComponent<Cubevar>().xpos, selection1.GetComponent<Cubevar>().ypos, selection1.GetComponent<Cubevar>().zpos] =
                            GameController.grid[selection2.GetComponent<Cubevar>().xpos, selection2.GetComponent<Cubevar>().ypos, selection2.GetComponent<Cubevar>().zpos];

                            GameController.grid[selection2.GetComponent<Cubevar>().xpos, selection2.GetComponent<Cubevar>().ypos, selection2.GetComponent<Cubevar>().zpos] =
                            colour[selectionHold.GetComponent<Cubevar>().xpos, selectionHold.GetComponent<Cubevar>().ypos, selectionHold.GetComponent<Cubevar>().zpos];
                            music.volume = titleScript.volumelvl;
                            music.PlayOneShot(swapnoise, 1);
                            lightScript.destroy = true;
                            GameController.matchCheck();
                            // GameController.refreshGrid(); removing this means the code will be more efficiant as refresggrid() is called at the beginning of mathchcheck now.
                            // Debug.Log("swappable");
                        }
                        else
                        {
                            // Debug.Log("not swappable");
                        }
                        selectionCounter = 0; //lets you select the first cube again
                    }
                }
                catch
                {
                    selection1 = null;
                    selection2 = null; //if you goof it resets both selestions.
                    selectionHold = null;
                    selectionCounter = 0;
                    lightScript.destroy = true;
                    //  Debug.Log("try clicking a cube numbnuts");
                }
               // Debug.Log("you selected this" + hit.collider.gameObject.name);
               // Debug.Log("seletion1" + selection1);
               // Debug.Log("seletion2" + selection2);
            }
        }
    }
    
}
