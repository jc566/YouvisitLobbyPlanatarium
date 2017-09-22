using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotateAround : MonoBehaviour {

    public float initialDistance;  // the distance from the centeral object
    public float speed;            // The linear speed
    [SerializeField]
    private GameObject centralObject;  //Reference to the central object
    private float currentDistance; 
    private float angularVelocity; 


    void Start()
    {
        //Conver the linear speed to angular speed
        angularVelocity = speed / initialDistance;

    }


    void FixedUpdate()
    {
        //Rotate the object around the central object
        transform.RotateAround(centralObject.transform.position, Vector3.up, speed * Time.deltaTime);

        //Track and update the object distance from central object.
        currentDistance = Vector3.Distance(transform.position, centralObject.transform.position);
        transform.position = (transform.position - centralObject.transform.position).normalized * currentDistance + centralObject.transform.position;


    }
}
