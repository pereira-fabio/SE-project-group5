using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{

    //Create settings to restart when clicking on Button
    public void LoadGame(){
        //restart the game
        SceneManager.LoadScene("GameLevel");
        Time.timeScale = 1;
    }
}
