using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePacman : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

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
        //Check for ESC key press
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        // pause the game
        Time.timeScale = 0;
        // show the pause menu
        pauseMenu.SetActive(true);
        // set the isPaused variable to true
        isPaused = true;
    }

    public void ResumeGame(){
        // resume the game
        Time.timeScale = 1;
        // hide the pause menu
        pauseMenu.SetActive(false);
        // set the isPaused variable to false
        isPaused = false;
    }

    public void MainMenu(){
        // resume the game
        Time.timeScale = 1;
        // set the isPaused variable to false
        isPaused = false;
        // load the main menu scene
        SceneManager.LoadScene(0);
    }

    //Create a function to disable all the sounds
    public void MuteSound(){
        //Disable all the sounds
        AudioListener.volume = 0;
        StateValueConrtoller.mute = 0;
        //Disable the mute button
        muteImage.SetActive(false);
        //Enable the unmute button
        unmuteImage.SetActive(true);
    }

    //Create a function to enable all the sounds
    public void UnmuteSound(){
        //Enable all the sounds
        AudioListener.volume = 1;
        StateValueConrtoller.mute = 1;
        //Enable the mute button
        muteImage.SetActive(true);
        //Disable the unmute button
        unmuteImage.SetActive(false);
    }
}

