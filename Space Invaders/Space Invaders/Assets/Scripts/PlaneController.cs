using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 3f;
    //Get horizontal key input
    public float horizontalInput;

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
}
