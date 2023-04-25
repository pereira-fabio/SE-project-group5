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

        // check if the object that collided with this object has the tag "Limit" and also if "Enemy" is not the tag of the object that collided with this object
        if (other.gameObject.tag == "Limit") {
            //Change the position to go down
            transform.position = new Vector3(transform.position.x, transform.position.y -3, transform.position.z);
            // if it does, change the direction of the movement
            speed = -speed;
        }

        // Check for collision with "TopDownLimit" tag and delete the object
        if (other.gameObject.tag == "TopDownLimit") {
            Destroy(gameObject);
        }
    }
}
