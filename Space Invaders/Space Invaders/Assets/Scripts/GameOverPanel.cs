using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameSettings gameSettings;
    public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        gameObject.SetActive(false);
        gameSettings.LoadGame();
    }
    
}