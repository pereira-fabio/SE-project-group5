using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolMaterialMovement : MonoBehaviour
{
    // speed of the object
    public float speed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
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
    }
}
