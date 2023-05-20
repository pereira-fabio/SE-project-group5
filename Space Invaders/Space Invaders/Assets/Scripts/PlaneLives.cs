using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // if the plane collides with an enemy
        if(other.collider.gameObject.tag == "Enemy") {
            // destroy the enemy
            Destroy(other.collider.gameObject);
            // create an explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // decrease the lives
            lives -= 1;
            // update the lives UI
            for (int i = 0; i < livesUI.Length; i++){
                if(i < lives) {
                    livesUI[i].enabled = true;
                } else {
                    livesUI[i].enabled = false;
                }
            }
            // if the lives are 0 or less, destroy the plane
            if(lives <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
