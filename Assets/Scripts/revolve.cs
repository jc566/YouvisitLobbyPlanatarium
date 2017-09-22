using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolve : MonoBehaviour {
	public float old_speed;
	public float speed;
	public float x, y, z;

	void Start () {
		transform.position = new Vector3(x, y, z); // This line ensures the Plaet_pos gamebject is placed in the center of the sun. this way the child of 
		//  this game object planetHolder, will rotate i a circle. 					
	}
	public void setRottoSpeed()
	{

		speed = old_speed;  //this function is called when the pointer exit event is triggered on a planet 

	}
	public void setRottoZero()
	{

		speed = 0; //this function is called when the pointer enter event is triggered on a planet 

	}
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,speed,0); //this roates the PLanet_pos gameobject everyframe, causing its children to automatically revolve around the sun


	}
}
