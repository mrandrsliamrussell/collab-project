using UnityEngine;
using System.Collections;



public class gridScript : MonoBehaviour {
    public GameObject[,,] cube = new GameObject[globalArrayLength, globalArrayLength, globalArrayLength]; //holds the gameobjects
    public GameObject newcube; // prefab for cube gameobject
    public static int globalArrayLength = 6;
    // Use this for initialization
    public int[,,] grid = new int[globalArrayLength, globalArrayLength, globalArrayLength];    //holds colour of cube at the same address of the gameobjects
    [SerializeField]
    Texture cube_blue;   // texture cubes use
    [SerializeField]
    Texture cube_yellow;
    [SerializeField]
    Texture cube_green;
    [SerializeField]
    Texture cube_orange;
    [SerializeField]
    Texture cube_pink;
    [SerializeField]
    Texture cube_red;
    [SerializeField]
    Texture holdTex;
    [SerializeField]
    Texture cube_bomb;
    Cubevar selected;
    public int i ;  // i,j,k loop counting variables
    public int j ;
    public int k ;
    public int score; // holds player score
    float timeleft = 30;
    float maxtime = 30;
    int xcombo = 0; //shows how many cubes in a row there are
    int ycombo = 0;
    int zcombo = 0;
    private float camy = 0;
    private float camz = 0;
   // private Vector3 camRot;
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "score " + score.ToString()); // diaplays score
        GUI.Box(new Rect(20, 40, 50, timeleft * 18), "TIME"); // displays time
    }
    void Start () {
        timeleft = 30;
        drawGrid(); // draws initial gris of cubes and assigns colour
        transform.Translate((globalArrayLength - 6) * 3.5f, (globalArrayLength - 6) * 3.5f, (globalArrayLength - 6) * 3.5f);
    }	
	// Update is called once per frame
	void FixedUpdate () {
        //****************************************************************************************************************
        if (Input.GetKey("w"))  //camera rotation input and controlls
        {
            camz -= 1;
        }
        if (Input.GetKey("s"))
        {
            camz += 1;
        }
        if (Input.GetKey("a"))
        {
            camy -= 1;
        }
        if (Input.GetKey("d"))
        {
            camy += 1;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, camy, camz);
        //timer       
        timeleft -= Time.deltaTime ;
        if (timeleft < 0)
        {           
            Application.LoadLevel("title scene");
            if(score > titleScript.highscoreValue)
            {
                titleScript.highscoreValue = score;
            }           
        }
        //Debug.Log(maxtime);
        //*******************************************************************************************************************************
    }
    public int randomNumber()                             //random number generator
    {
        return Random.Range(1, 7);
    }
    //***********************************************************************************************************************************
    // draws cubes on grid
    void drawGrid()
    {
        i = 0;
        j = 0;
        k = 0;
        for (k = 0; k < globalArrayLength - 1; k++)
        {
            for (j = 0; j < globalArrayLength - 1; j++)
            {
                for (i = 0; i < globalArrayLength - 1; i++)
                {                   
                    cube[i, j, k] = Instantiate(newcube, new Vector3(i * 7, j * 7, k * 7), Quaternion.identity) as GameObject;   // creates a new cube in the array
                    cube[i, j, k].name = "cube" + i + j + k;  // renames the cube to make it easier to find for debugging purposes
                    cube[i, j, k].GetComponent<Cubevar>().xpos = i; //assigns x,y,z co ordinates to the new cube
                    cube[i, j, k].GetComponent<Cubevar>().ypos = j;
                    cube[i, j, k].GetComponent<Cubevar>().zpos = k;
                    grid[i, j, k] = randomNumber();  // assigns a random number to the array whos address corrosponds to the same as the gameobject array
                    switch (grid[i, j, k]) // puts a random colour onto the cubes
                    {
                        case 1:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_blue;
                            break;
                        case 2:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_red;
                            break;
                        case 3:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_orange;
                            break;
                        case 4:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_yellow;
                            break;
                        case 5:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_pink;
                            break;
                        case 6:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_green;
                            break;
                    }                                     
                }
                i = 0;
            }
            j = 0;
        }
        matchCheck();
        score = 0; 
    }    
  public void refreshGrid() //updates grid with new colours for any cubes that have changed  
    {
        i = 0;
        j = 0;
        k = 0;
        for (k = 0; k < globalArrayLength - 1; k++)
        {
            for (j = 0; j < globalArrayLength - 1; j++)
            {
                for (i = 0; i < globalArrayLength - 1; i++)
                {
                   Destroy(cube[i, j, k]); //the game actually performes faster if i destroy and redraw the entire grid
                    cube[i, j, k] = Instantiate(newcube, new Vector3(i * 7, j * 7, k * 7), Quaternion.identity) as GameObject;
                    cube[i, j, k].name = "cube" + i + j + k;
                    cube[i, j, k].GetComponent<Cubevar>().xpos = i;
                    cube[i, j, k].GetComponent<Cubevar>().ypos = j;
                    cube[i, j, k].GetComponent<Cubevar>().zpos = k;                   
                    switch (grid[i, j, k])
                    {
                        case 1:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_blue;
                            break;
                        case 2:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_red;
                            break;
                        case 3:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_orange;
                            break;
                        case 4:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_yellow;
                            break;
                        case 5:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_pink;
                            break;
                        case 6:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_green;
                            break;
                        case 7:
                            cube[i, j, k].GetComponent<Renderer>().material.mainTexture = cube_bomb;
                            break;
                    }
                }
                i = 0;
            }
            j = 0;
        }        
    }

    public void matchCheck() //checks the matches in the cube
    {
        refreshGrid();       
          int l ; //using a different set of loop variables as refresh grid is called several times in this method and they would screw with this loop
          int m ;
          int n ;
         xcombo = 0;
         //sweep x axis for matches
         for (l = 0; l < globalArrayLength; l++)     // the letter k is unclean and must be purged
         {
             xcombo = 0;
             for (m = 0; m < globalArrayLength; m++)
             {
                 xcombo = 0;
                 for (n = 0; n < globalArrayLength; n++)
                 {
                     if (n > 0)
                     {
                         if (((grid[n - 1, m, l] == grid[n, m, l]) || grid[n - 1, m, l] == 7) && (xcombo < 6) && grid[n,m,l] != 0) //grid[n,m,l] != 0 this should stop the y axis finding loads of matches, 7 is for bomb which is also a wild cube
                         {
                             xcombo += 1;
                         }
                         else
                         {
                                 switch (xcombo) //x combo checks how mant in a row are the same colour
                                 {
                                     case 4:
                                        // Debug.Log("match 5" + cube[n - 1, m, l] + cube[n - 2, m, l] + cube[n - 3, m, l] + cube[n - 4, m, l] + cube[n - 5, m, l]);
                                         grid[n - 1, m, l] = randomNumber();
                                         grid[n - 2, m, l] = randomNumber();
                                         
                                         grid[n - 4, m, l] = randomNumber();
                                         grid[n - 5, m, l] = randomNumber(); // assigns a new colour to matched cube
                                         
                                         score += 2000; //increases the score
                                         xcombo = 0;
                                    grid[n - 3, m, l] = 7;
                                    if (grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7)
                                    {
                                        for (n = 0; n < globalArrayLength; n++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    matchCheck(); //once a set of cubes are matched it goes through again to check for any other matches also recursion.
                                         break;
                                     case 3:
                                        // Debug.Log("match 4" + cube[n - 1, m, l] + cube[n - 2, m, l] + cube[n - 3, j, l] + cube[n - 4, m, l]);
                                         grid[n - 1, m, l] = randomNumber();
                                         grid[n - 2, m, l] = randomNumber();
                                         
                                         grid[n - 4, m, l] = randomNumber();
                                         
                                         score += 1000;
                                         xcombo = 0;
                                    if (grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7)
                                    {
                                        for (n = 0; n < globalArrayLength; n++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    grid[n - 3, m, l] = 7;
                                    matchCheck();
                                         break;
                                     case 2:
                                       //  Debug.Log("match 3" );
                                         grid[n - 1, m, l] = randomNumber();
                                         grid[n - 2, m, l] = randomNumber();
                                         grid[n - 3, m, l] = randomNumber();
                                         score += 500;
                                         xcombo = 0;
                                    if (grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7 || grid[n - 1, m, l] == 7)
                                    {
                                        for (n = 0; n < globalArrayLength; n++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    matchCheck();
                                         break;
                                }
                            // Debug.Log("combo" + xcombo);
                             xcombo = 0;
                         }
                     }
                 }
                 n = 0;
             }
             m = 0;
             xcombo = 0;
         }
         //using a different set of loop variables as refresh grid is called several times in this method and they would screw with this loop       
        ycombo = 0;
        //sweep x axis for matches
        l = 0;
        m = 0;
        n = 0;
        for (n = 0; n < globalArrayLength; n++)     // the letter k is unclean and must be purged
        {
            ycombo = 0;
            for (l = 0; l < globalArrayLength; l++)
            {
                ycombo = 0;
                for (m = 0; m < globalArrayLength; m++)         // n = m m = l l = n
                {
                    if (m > 0)
                    {
                        if (((grid[n , m - 1, l] == grid[n, m, l]) || grid[n,m-1,l] == 7 ) && (xcombo < 6) && grid[n, m, l] != 0) //grid[n,m,l] != 0 this should stop the y axis finding loads of matches
                        {
                            ycombo += 1;
                        }
                        else
                        {
                            switch (ycombo) //x combo checks how mant in a row are the same colour
                            {
                                case 4:
                                   // Debug.Log("match 5");
                                    grid[n , m - 1, l] = randomNumber();
                                    grid[n , m - 2, l] = randomNumber();
                                    
                                    grid[n , m - 4, l] = randomNumber();
                                    grid[n , m - 5, l] = randomNumber(); // assigns a new colour to matched cube
                                    score += 2000; //increases the score
                                    ycombo = 0;
                                    if (grid[n, m - 1, l] == 7 || grid[n, m - 2, l] == 7 || grid[n, m - 3, l] == 7 || grid[n, m - 4, l] == 7 || grid[n, m - 5, l] == 7)
                                    {
                                        for (m = 0; m < globalArrayLength; m++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    grid[n, m - 3, l] = 7;
                                    matchCheck(); //once a set of cubes are matched it goes through again to check for any other matches also recursion.
                                    break;
                                case 3:
                                    //Debug.Log("match 4");
                                    grid[n , m - 1, l] = randomNumber();
                                    grid[n , m - 2, l] = randomNumber();
                                    
                                    grid[n , m - 4, l] = randomNumber();
                                    score += 1000;
                                    ycombo = 0;
                                    if (grid[n, m - 1, l] == 7 || grid[n, m - 2, l] == 7 || grid[n, m - 3, l] == 7 || grid[n, m - 4, l] == 7)
                                    {
                                        for (m = 0; m < globalArrayLength; m++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    grid[n, m - 3, l] = 7;
                                    matchCheck();                          
                                    break;
                                case 2:
                                   
                                    //  Debug.Log("match 3");
                                    grid[n , m - 1, l] = randomNumber();
                                    grid[n , m - 2, l] = randomNumber();
                                    grid[n , m - 3, l] = randomNumber();
                                    score += 500;
                                    ycombo = 0;
                                    if (grid[n, m - 1, l] == 7 || grid[n, m - 2, l] == 7 || grid[n, m - 3, l] == 7)
                                    {
                                        for (m = 0; m < globalArrayLength; m++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    matchCheck();
                                    break;
                            }
                            //Debug.Log("combo" + xcombo);
                            ycombo = 0;
                        }
                    }
                }
                m = 0;
            }
            l = 0;
            ycombo = 0;
        }
        //using a different set of loop variables as refresh grid is called several times in this method and they would screw with this loop
        zcombo = 0;
        //sweep z axis for matches
        l = 0;
        m = 0;
        n = 0;
        for (n = 0; n < globalArrayLength; n++)     // the letter k is unclean and must be purged
        {
            zcombo = 0;
            for (m = 0; m < globalArrayLength; m++)
            {
                zcombo = 0;
                for (l = 0; l < globalArrayLength; l++)         // mnl
                {
                    if (l > 0)
                    {
                        if (((grid[n, m , l - 1] == grid[n, m, l]) || grid[n, m, l-1] == 7) && (zcombo < 6) && grid[n, m, l] != 0) //grid[n,m,l] != 0 this should stop the y axis finding loads of matches
                        {
                            zcombo += 1;
                        }
                        else
                        {
                            switch (zcombo) //x combo checks how mant in a row are the same colour
                            {
                                case 4:
                                   
                                        // Debug.Log("match 5");
                                    grid[n, m , l - 1] = randomNumber();
                                    grid[n, m , l - 2] = randomNumber();
                                    
                                    grid[n, m , l - 4] = randomNumber();
                                    grid[n, m , l - 5] = randomNumber(); // assigns a new colour to matched cube
                                    score += 2000; //increases the score
                                    zcombo = 0;
                                    if (grid[n, m, l - 1] == 7 || grid[n, m, l - 2] == 7 || grid[n, m, l - 3] == 7 || grid[n, m, l - 4] == 7 || grid[n, m, l - 5] == 7)
                                    {
                                        for (l = 0; l < globalArrayLength; l++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    grid[n, m, l - 3] = 7;
                                    matchCheck(); //once a set of cubes are matched it goes through again to check for any other matches also recursion.
                                    break;
                                case 3:
                                    
                                    // Debug.Log("match 4");
                                    grid[n, m, l - 1] = randomNumber();
                                    grid[n, m, l - 2] = randomNumber();
                                    grid[n, m, l - 3] = 7;
                                    grid[n, m, l - 4] = randomNumber();
                                    score += 1000;
                                    zcombo = 0;
                                    if (grid[n, m, l - 1] == 7 || grid[n, m, l - 2] == 7 || grid[n, m, l - 3] == 7 || grid[n, m, l - 4] == 7)
                                    {
                                        for (l = 0; l < globalArrayLength; l++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }
                                    grid[n, m, l - 3] = 7;
                                    matchCheck();
                                    break;
                                case 2:
                                  
                                    //  Debug.Log("match 3");
                                    grid[n, m, l - 1] = randomNumber();
                                    grid[n, m, l - 2] = randomNumber();
                                    grid[n, m, l - 3] = randomNumber();
                                    score += 500;
                                    zcombo = 0;
                                    if (grid[n, m, l - 1] == 7 || grid[n, m, l - 2] == 7 || grid[n, m, l - 3] == 7)
                                    {
                                        for (l = 0; l < globalArrayLength; l++)
                                        {
                                            grid[n, m, l] = randomNumber();
                                            score += 2000;
                                        }
                                    }

                                    matchCheck();
                                    break;
                            }
                          //  Debug.Log("combo" + xcombo);
                            zcombo = 0;
                        }
                    }
                }
                l = 0;
            }
            m = 0;
            zcombo = 0;           
        }
        refreshGrid();
        maxtime = maxtime - (maxtime / 95); //after each match total time desreases relatively by 5%
        timeleft = maxtime;
    }
}

