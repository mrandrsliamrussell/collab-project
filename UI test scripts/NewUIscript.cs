using UnityEngine;
using System.Collections;


public class NewUIscript : MonoBehaviour {
    [SerializeField]
    GameObject slider;
    [SerializeField]
    bool slidertoggle = false;
    
    void Start()
    {
        slider.SetActive(false);
        slidertoggle = false;
    }
    
    
    
    
    // Use this for initialization





    public void startgame() {
        Application.LoadLevel("main scene");

    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void options()
    {
        if (slidertoggle == false)
        {
            slidertoggle = true;
            slider.SetActive(true);
        }
        else if(slidertoggle == true)
        {
            slidertoggle = false;
            slider.SetActive(false);
        }
    }
	
	
}
