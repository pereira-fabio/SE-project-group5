using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCController1 : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact(){
        Debug.Log("Interacting with PC");
        StartDialog();
        
        Invoke("LoadScene", 3f);
    }

    public void StartDialog(){
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    public void LoadScene(){
        SceneManager.LoadScene(2); //Tetris
    }
}
