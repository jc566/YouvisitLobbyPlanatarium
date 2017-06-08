using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modded_fire_soft : MonoBehaviour {
    //Make reference to the particle system attached
    public ParticleSystem PSone;

    //Scale change vector values
    public float scaleX = .1f;
    public float scaleY = .1f;
    public float scaleZ = .1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        alterPSone();
	}

    public void alterPSone()
    {
        //Make reference to the Emission of PSone.

        //Make reference to the Scale of the PSone particle system
        PSone.transform.localScale = new Vector3(scaleX += 0.003f, scaleY += 0.003f, scaleZ += 0.003f);
    }
}
