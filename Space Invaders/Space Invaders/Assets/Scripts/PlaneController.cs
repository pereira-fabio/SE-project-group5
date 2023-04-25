using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public float speed = 3f;
    //Get horizontal key input
    public float horizontalInput;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get horizontal key input
        horizontalInput = Input.GetAxis("Horizontal");
        //Move the plane
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        // check if the object that collided with this object has the tag "Enemy"
        if(other.gameObject.tag == "Enemy") {
            // create a new explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // if it does, destroy both objects
            Destroy(other.gameObject);
            lives -= 1;
        }
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
