using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    //Create variable for PLane 
    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            // if the game is paused
            if(isPaused){
                // resume the game
                ResumeGame();
            } else {
                // pause the game
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        // pause the game
        Time.timeScale = 0;
        // show the pause menu
        pauseMenu.SetActive(true);

        //Pause script of variable plane
        plane.GetComponent<PlaneAmmunition>().enabled = false;

        // set the isPaused variable to true
        isPaused = true;
    }



    public void ResumeGame(){
        // resume the game
        Time.timeScale = 1;
        // hide the pause menu
        pauseMenu.SetActive(false);

        //Activate the PlaneAmmunition Script of Plane
        plane.GetComponent<PlaneAmmunition>().enabled = true;

        // set the isPaused variable to false
        isPaused = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Main Menu");
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}
