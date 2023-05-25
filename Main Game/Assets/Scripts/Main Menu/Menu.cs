using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create a function to load the game scene
    public void PlayGame(){
        //Load the game scene
        SceneManager.LoadScene(0);
    }

    //Create a function to stop the game
    public void QuitGame(){
        //Quit the game
        Application.Quit();
    }

    //Create a function to disable all the sounds
    public void MuteSound(){
        //Mute all the sounds
        AudioListener.pause = !AudioListener.pause;
    }
}
