//Elisa Reyes
// 9-22-24
//This file handles the movement of the pickup objects.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 2.0f;
    private Rigidbody2D rb2dPickUp;

    // Start is called before the first frame update
    void Start()
    {
        rb2dPickUp = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); //rotates the pickup objects
       
       //moves the pickup objects in random directions
        transform.position += new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0f) * Time.deltaTime;
    }  
}
