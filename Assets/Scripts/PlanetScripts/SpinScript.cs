using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {


    public float spinSpeed;
    //Toggle Which Version of Spin
    public bool spinRegular = false;
    public bool spinInverted = false;
    //Spin Direction Options
    public bool spinForward = false;
    public bool spinLeft = false;
    public bool spinRight = false;
    public bool spinBackward = false;

    // Use this for initialization
    void Start () {
        //set default speed to the Spin Speed
        //spinSpeed = 1.0f;

    }
	
	// Update is called once per frame
	void Update () {
        //if the item is a regular (0,0,0) Vector 3
        if(spinRegular)
        {
            spinItem();
        }
        //if the item is a inverted (-90,0,0) Vector 3
        if(spinInverted)
        {
            spinInvertedItem();
        }
     
	}

    //Regular Vector 3 at Defaults of Zero
    public void spinItem()
    {
        //Spin the item in place...

        if (spinLeft)
        {
            this.gameObject.transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed);
        }
        if(spinRight)
        {
            this.gameObject.transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed * -1.0f);
        }
        if(spinForward)
        {
            this.gameObject.transform.Rotate(Vector3.left, Time.deltaTime * spinSpeed);
        }
        if(spinBackward)
        {
            this.gameObject.transform.Rotate(Vector3.right, Time.deltaTime * spinSpeed);
        }
    }
    //Inverted X rotation of -90
    public void spinInvertedItem()
    {
        if (spinLeft)
        {
            this.gameObject.transform.Rotate(new Vector3(0,0,1), Time.deltaTime * spinSpeed);
        }
        if (spinRight)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * spinSpeed * -1.0f);
        }
        if (spinForward)
        {
            this.gameObject.transform.Rotate(new Vector3(1,0,0), Time.deltaTime * spinSpeed * -1.0f);
        }
        if (spinBackward)
        {
            this.gameObject.transform.Rotate(new Vector3(1, 0, 0), Time.deltaTime * spinSpeed);
        }
    }
            
   
}
