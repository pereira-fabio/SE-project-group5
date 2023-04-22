using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolMaterialMovement : MonoBehaviour
{
    // speed of the object
    public float speed = 2f;
    public float difficulty = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the object to the right
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // check if the object that collided with this object has the tag "Limit"
        if (other.gameObject.tag == "Limit") {
            //Change the position to go down
            transform.position = new Vector3(transform.position.x, transform.position.y -1, transform.position.z);
            // if it does, change the direction of the movement
            speed = -speed;
        }
    }
}
