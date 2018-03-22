using UnityEngine;
using System.Collections;

public class boxSpawner : MonoBehaviour {
    [SerializeField]
    public GameObject newcubeSpawn;
    [SerializeField]
    public Texture cube_blue;
    [SerializeField]
    public Texture cube_yellow;
    [SerializeField]
    public Texture cube_green;
    [SerializeField]
    public Texture cube_orange;
    [SerializeField]
    public Texture cube_pink;
    [SerializeField]
    public Texture cube_red;

    // Use this for initialization
    void createCube()
    {
        newcubeSpawn = Instantiate(newcubeSpawn, new Vector3(Random.Range(0, 20), 100, Random.Range(0, 20)), Quaternion.identity) as GameObject;
        newcubeSpawn.name = "cube";
        switch (Random.Range(0, 6))
        {
            case 0:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_blue;
                break;
            case 1:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_red;
                break;
            case 2:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_orange;
                break;
            case 3:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_yellow;
                break;
            case 4:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_pink;
                break;
            case 5:
                newcubeSpawn.GetComponent<Renderer>().material.mainTexture = cube_green;
                break;
        }
    }	
	// Update is called once per frame
	void Update()
    {
        createCube();
	}
}
