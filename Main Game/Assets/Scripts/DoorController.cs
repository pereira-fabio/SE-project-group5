using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact(){
        // Debug.Log("Interacting with Door");
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}
