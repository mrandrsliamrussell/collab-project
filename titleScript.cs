using UnityEngine;
using System.Collections;

public class titleScript : MonoBehaviour
{
    public Texture start;
    public Texture quit;
    public Texture highscore;
    public Texture options;
    public Texture h2p;
    bool showsplash;
    bool showvol;
    bool showhighscore;
    public static float volumelvl = 1;
    public static int highscoreValue;
    public  AudioClip buttonSelect;
    public Texture splashScreen;
    AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
        volumelvl = 1.0F;
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 100), start))
        {
            music.PlayOneShot(buttonSelect, 1);            
            Application.LoadLevel("main scene");
        }
        if (GUI.Button(new Rect(10, 130, 100, 100), quit))
        {
            music.PlayOneShot(buttonSelect, 1);
            Application.Quit();
        }
        if (GUI.Button(new Rect(10, 250, 100, 100), highscore))
        {
            music.PlayOneShot(buttonSelect, 1);
            if (showhighscore == false)
            {
                showhighscore = true;
            }
            else if (showhighscore == true)
            {
                showhighscore = false;
            }
        }
        if (GUI.Button(new Rect(10, 370, 100, 100), options))
        {
            music.PlayOneShot(buttonSelect, 1);
            if (showvol == false)
            {
                showvol = true;
            }
            else if (showvol == true)
            {
                showvol = false;
            }

        }
        if (GUI.Button(new Rect(10, 490, 100, 100), h2p))
        {
            music.PlayOneShot(buttonSelect, 1);
            if (showsplash == false)
            {
                showsplash = true;
            }
            else if (showsplash == true)
            {
                showsplash = false;
            }

        }
        if (showsplash == true)
        {
            GUI.Box(new Rect(120, 20, 1200, 720), splashScreen);
        }
        if (showvol == true)
        {
            volumelvl = GUI.HorizontalSlider(new Rect(120, 385, 200, 30), volumelvl, 0.0F, 1.0F);
            GUI.Box(new Rect(330, 370, 80, 35), "Volume");

            if (GUI.Button(new Rect(120, 420, 50, 35), "5x5x5"))
            {
                gridScript.globalArrayLength = 6;
            }
            
            if (GUI.Button(new Rect(180, 420, 50, 35), "6x6x6"))
            {
                gridScript.globalArrayLength = 7;
            }
            
            if (GUI.Button(new Rect(240, 420, 50, 35), "7x7x7"))
            {
                gridScript.globalArrayLength = 8;
            }
            GUI.Box(new Rect(330, 420, 80, 35), "Grid Size");
        }
        if (showhighscore == true)
        {
            GUI.Box(new Rect(120, 300, 150, 35), "Highscore " + highscoreValue);
        }

    }
}
