using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAmmunition : MonoBehaviour
{
    public GameObject ammunitionPrefab;
    //Create a sound source for shooting
    public AudioSource shootSource;
    //Add a shooting sound source
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            // create a new ammunition
            GameObject newAmmunition = Instantiate(ammunitionPrefab, transform.position, Quaternion.identity);
            // move the ammunition up
            newAmmunition.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            // play the shooting sound
            shootSource.clip = shootSound;
            shootSource.Play();
        }
    }
}
