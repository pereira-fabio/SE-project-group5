using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SchoolMaterialMovement : MonoBehaviour
{
    // speed of the object
    public float speed = 2f;
    //play a sound when the object is destroyed
    public AudioSource destroySource;
    //Add a sound to the object
    public AudioClip destroySound;
    //Create variable for VicotryPanel
    public GameObject VictoryPanel;
    //Set GameObject for SchoolMaterial
    public GameObject SchoolMaterial;

    public GameObject BombDrop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        //Count prefabs inside SchoolMaterial
        int count = SchoolMaterial.transform.childCount;
        if(count == 0) {
            //Call the win method
            win();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Check if there's a collision with the object

        //Create a movement for space invaders monsters when they hit the limit that they go down for 1 block and change direction
        if(other.gameObject.tag == "Limit") {
            //Change the direction of the object
            speed = speed * -1;
            //Move the object down at least the height of the object
            transform.Translate(Vector2.down * Time.deltaTime * 20);
        }

        // Check for collision with "TopDownLimit" tag and delete the object
        if (other.gameObject.tag == "TopDownLimit") {
            Destroy(gameObject);
        }

        //Check if there's a collision with "ammunition" tag and play sound
        if(other.gameObject.tag == "Ammunition") {
            // play the explosion sound
            destroySource.clip = destroySound;
            destroySource.Play();
        }

    }

    //Create a win method when the player wins
    public void win() {
        StateValueConrtoller.stateValue +=30;
        VictoryPanel.SetActive(true);
        BombDrop.SetActive(false);
    }

    //Create method to continue to the next level
    public void Continue() {
        //Load the next scene
        SceneManager.LoadScene(0);
        
    }
}
