using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Set two Buttons for mute and unmute
    public GameObject muteImage;
    public GameObject unmuteImage;

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
        //Disable all the sounds
        AudioListener.volume = 0;
        //Disable the mute button
        muteImage.SetActive(false);
        //Enable the unmute button
        unmuteImage.SetActive(true);
    }

    //Create a function to enable all the sounds
    public void UnmuteSound(){
        //Enable all the sounds
        AudioListener.volume = 1;
        //Enable the mute button
        muteImage.SetActive(true);
        //Disable the unmute button
        unmuteImage.SetActive(false);
    }
}
