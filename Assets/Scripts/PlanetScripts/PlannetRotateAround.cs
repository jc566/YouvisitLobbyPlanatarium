using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlannetRotateAround: MonoBehaviour {

    public float distance;  //the distance front the center
    public float speed;     //The linear speed
    public bool moving;     //true and false, the planet start obiting if it is true
                            //stop obiting if it is false 
    [SerializeField]
    private GameObject centralObject;  //Reference to the central object
    private Vector3 axis;              //axis of rotation
    static public float angularSpeed;  //Angular speed

    static public float orginalspeed;  
    
	// Use this for initialization
	void Awake () {
        //Initiallize the moving to true.
		moving = true;	

        //Randomly position the object within the distance as radius from the central Object;
        transform.position = new Vector3(Random.Range(-centralObject.transform.position.x-distance, centralObject.transform.position.x+distance), centralObject.transform.position.y,
            Random.Range(centralObject.transform.position.z-distance, centralObject.transform.position.z + distance));

        //Keep the distance betwee the objects
        transform.position = (transform.position - centralObject.transform.position).normalized * distance + centralObject.transform.position;

        //Get the axis of the rotation
        axis = centralObject.transform.up;

        //Convert the Standard velocity to Angular velocity
        angularSpeed = speed / distance;

        orginalspeed = angularSpeed;

    }
	
	void FixedUpdate () {
        //Self_rotation
        //transform.Rotate(Vector3.up * Time.deltaTime);

        //Roate Around the the object with the "Speed(Angle)" per frame;
        if(moving){
        	transform.RotateAround(centralObject.transform.position, axis, angularSpeed * Time.deltaTime);
       	}
	}

    public void setMoveTrue()
    {
        moving = true;
    }
    public void setMoveFalse()
    {
        moving = false;
    }
}
