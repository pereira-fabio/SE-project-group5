using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact(){
        // Debug.Log("Interacting with Door");
        if(StateValueConrtoller.stateValue >= 100){
           SceneManager.LoadScene(6);
        }else{
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }
}
