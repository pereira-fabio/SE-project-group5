using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropper : MonoBehaviour
{
    public float speed = 5f;
    //Bomb prefab
    public GameObject bombPrefab;
    //Bomb drop rate
    public float dropRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move left to right
        transform.Translate(Vector2.left * Time.deltaTime * speed);
        //Drop a bomb
        if(Random.value < dropRate * Time.deltaTime) {
            //Create a new bomb
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        //Check if the object that collided with this object has the tag "Limit"
        if(other.gameObject.tag == "Limit") {
            //Change direction
            speed *= -1;
        }
    }
}