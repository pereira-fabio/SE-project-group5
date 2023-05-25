using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    //Get plane object
    public GameObject plane;

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
        //Desactivate plane script "Plane Ammuntion" inside plane
        plane.GetComponent<PlaneAmmunition>().enabled = false;
        // set the isPaused variable to true
        isPaused = true;
    }

    public void ResumeGame(){
        // resume the game
        Time.timeScale = 1;
        // hide the pause menu
        pauseMenu.SetActive(false);
        //Desactivate plane script "Plane Ammuntion" inside plane
        plane.GetComponent<PlaneAmmunition>().enabled = true;
        // set the isPaused variable to false
        isPaused = false;
    }

    public void MainMenu(){
        // resume the game
        Time.timeScale = 1;
        // set the isPaused variable to false
        isPaused = false;
        // load the main menu scene
        SceneManager.LoadScene(4);
    }
}
