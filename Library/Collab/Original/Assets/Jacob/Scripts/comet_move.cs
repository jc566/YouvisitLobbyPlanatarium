using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comet_move : MonoBehaviour {

    // Use this for initialization

    Rigidbody body;

   private float timer = 15;
	void Start () {

        //reference this objects rigidbody
        body = transform.GetComponent<Rigidbody>();

        

	}
	
	// Update is called once per frame
	void Update () {
        //determine how long the comet stays alive for
        timer -= Time.deltaTime;

        body.rotation = Random.rotation;

        body.velocity += -transform.forward * Time.deltaTime * 4 * body.velocity.magnitude;
        //once the lifetime timer is up, destroy the object
        if(timer < 0)
        {
            DestroyObject(transform.gameObject);
        }

	}
}
