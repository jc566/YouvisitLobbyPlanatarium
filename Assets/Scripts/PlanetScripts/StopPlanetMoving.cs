using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlanetMoving : MonoBehaviour {
	//This script is currently designed to attach on the parent object;
	//public GameObject Parent;   //<--Uncommen this line to use different game object as parent of Planet, and then change parent object in the code below accordingly

	//This script contain the function to stop and continue the motion of the Planets


	//An array contained all planet that are going to stop
	public GameObject[] Planets;

	//An array use to temporarily store list of "PlannetRotateAround Script; 
	private PlannetRotateAround[] ChildComponents;

	//Let Planet stop moving
	public void StopRotateAround(){
		//Make Plannet as child of this game object;
		foreach(GameObject obj in Planets){
			obj.transform.SetParent(this.gameObject.transform);
		}

		//Get the list of "PlannetRoateAround" Script form children
		ChildComponents = this.gameObject.GetComponentsInChildren<PlannetRotateAround>();

		//Stop children Planet from moving by change the "moving" variable to false;
		foreach(PlannetRotateAround child in ChildComponents){
			child.moving = false;
		}
	}


	//Let Planet move again;
	public void ContinueMoving(){
		//Get the list of "PlannetRoateAround" Script form children
		ChildComponents = this.gameObject.GetComponentsInChildren<PlannetRotateAround>();

		//change moving back to true;
		foreach(PlannetRotateAround child in ChildComponents){
			child.moving = true;
		}
	}

}
