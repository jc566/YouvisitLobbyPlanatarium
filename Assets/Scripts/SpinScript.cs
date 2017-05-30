using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {


    public float spinSpeed;
	// Use this for initialization
	void Start () {
        //set default speed to the Spin Speed
        spinSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        spinItem();
	}

    public void spinItem()
    {
        //Spin the item in place...
        this.gameObject.transform.Rotate(Vector3.up, Time.deltaTime * spinSpeed);
    }
}
