using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCController : MonoBehaviour, Interactable
{
    public void Interact(){
        Debug.Log("Interacting with PC");
        SceneManager.LoadScene(1);
    }
}
