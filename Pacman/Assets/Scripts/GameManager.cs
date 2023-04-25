
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    
    public Pacman pacman;
    public Transform pellets;
    public int score {get; private set;}
    public int lives {get; private set;}

    public int ghostMultipiler {get; private set;} = 1;

    // public Text scoreText;

    private void Start(){
        NewGame();
    }

    private void Update(){
        if (this.lives <= 0 && Input.anyKeyDown){
            NewGame();
        }
    }

    private void NewGame (){
        SetScore(0);
        SetLives(3);
        NewRound();

    }

    private void NewRound(){
        foreach (Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState(){
        ResetGhostMultipier();
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].ResetStateGhost();
        }

        this.pacman.ResetStatePac();
    }

    private void GameOver(){
        for (int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }
    private void SetScore(int score){
        this.score = score;
        // this.scoreText.text = score.ToString().PadLeft(2, '0');
    }

    private void SetLives(int lives){
        this.lives = lives;
    }

    public void GhostEaten(Ghost ghost){
        SetScore(this.score + (ghost.points * ghostMultipiler));
        this.ghostMultipiler++;
    }

    public void PacmanEaten(){
        this.pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);

        if(this.lives > 0){
            Invoke(nameof(ResetState), 3.0f);
        }
        else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet){
        pellet.gameObject.SetActive(false);

        SetScore(this.score + pellet.points);

        if(!HasRemainingPellets()){
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }

    }

    public void PowerPelletEaten(PowerPellet pellet){

        for(int i = 0; i < this.ghosts.Length; i++){
            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultipier), pellet.duration);
        
    }

    private bool HasRemainingPellets(){
        foreach (Transform pellet in this.pellets){
            if(pellet.gameObject.activeSelf){
                return true;
            }
        }
        return false;
    }

    private void ResetGhostMultipier(){
        this.ghostMultipiler = 1;
    }
}
