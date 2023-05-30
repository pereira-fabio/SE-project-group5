using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {FreeRoam, Dialog}; 

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public Text ectsText;

    GameState state;

    private void Start(){
        DialogManager.Instance.OnShowDialog += () =>{
            state = GameState.Dialog;
        };

        DialogManager.Instance.OnCloseDialog += () =>{
            if(state == GameState.Dialog){
                state = GameState.FreeRoam;
            }
            
        };
    }

    private void Update(){
        ectsText.text = StateValueConrtoller.stateValue.ToString();
        if(state == GameState.FreeRoam){
            playerController.HandleUpdate();
        }
        else if(state == GameState.Dialog){
            DialogManager.Instance.HandleUpdate();
        }
    }

    
}
