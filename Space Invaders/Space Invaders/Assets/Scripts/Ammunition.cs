using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the object up
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // check if the object that collided with this object has the tag "Enemy"
        if(other.gameObject.tag == "Enemy") {
            // create a new explosion
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // if it does, destroy both objects
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        // check if the object that collided with this object has the tag "Limit"
        if(other.gameObject.tag == "TopDownLimit") {
            // if it does, destroy this object
            Destroy(gameObject);
        }
    }
}
