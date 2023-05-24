using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 5f;
    public GameObject explosionPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the object down
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // check if the object that collided with this object has the tag "Player"
        if(other.gameObject.tag == "Plane") {
            // create a new explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // if it does, destroy both objects
            Destroy(gameObject);
        }

        // check if the object that collided with this object has the tag "Limit"
        if(other.gameObject.tag == "TopDownLimit") {
            // if it does, destroy this object
            Destroy(gameObject);
        }
    }
}