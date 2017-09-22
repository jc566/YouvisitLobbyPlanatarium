using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This works fine for Camera objects because it projects the Ray forward.
 * I dont know the orientation of the controllers by default, so that "forward" vector3
 * might need to be chagned to a vector3.up to make it mimic pointing.
 * 
 */
public class rayCastScript : MonoBehaviour {

    public float rayRange = 1000;//distance that the raycast reaches

    public bool sunIsClickable; //reference to whether or not the sun is allowed to be clicked

    //reference to the reticle raycaster
    GvrPointerPhysicsRaycaster reticle;
    // Use this for initialization
    void Start () {
        //link the reference to the reticle raycaster
        reticle = this.gameObject.GetComponent<GvrPointerPhysicsRaycaster>();

        //by default turn sunIsClickable to false
        sunIsClickable = false;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void FixedUpdate()
    {
        //create the ray from the forward direction of the gameobject this script is attached to
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 10;
        //draw the ray to be seen in editor
        Debug.DrawRay(this.transform.position, forward, Color.green);
        //create the ray
        Ray ray = new Ray(this.transform.position,this.transform.TransformDirection(Vector3.forward));
        RaycastHit hit = new RaycastHit();
        //if the ray hits something, print out the name of the object.
        if (Physics.Raycast(ray, out hit, rayRange))
        {
            GameObject objectToBeManipulated = hit.collider.gameObject; //temp copy of the item to be messed with
            //Debug.Log(hit.collider.gameObject.name);

            //if the reticle is over the sun and is not clickable, then disable reticle
            if (hit.collider.gameObject.name == "Sun_2" && sunIsClickable == false)
            {
                reticle.enabled = false;
            }
            //otherwise, enable the reticle
            else
            {
                reticle.enabled = true;
            }
           
            
        }
    }
}
