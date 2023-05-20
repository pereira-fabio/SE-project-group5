using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
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
}
