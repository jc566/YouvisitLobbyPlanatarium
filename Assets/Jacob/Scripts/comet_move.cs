using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comet_move : MonoBehaviour {

    // Use this for initialization

    Rigidbody body;

   private float timer = 10;
	void Start () {


        body = transform.GetComponent<Rigidbody>();

        

	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        
        body.velocity += -transform.forward * Time.deltaTime * 4;
        
        if(timer < 0)
        {
            DestroyObject(transform.gameObject);
        }

	}
}
