using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modded_fire_inhale_Script : MonoBehaviour {
    public ParticleSystem PSone; //Flares going towards the Center
    public ParticleSystem PStwo; //Inner flares going towards the Center
    public ParticleSystem PSthree;
    public float maxScale;

    //Variables to change PSones Emission Rate
    private float EMrate = 1.0f;
   


    //Scale Change Vector Values
    private float scaleX = .1f;
    private float scaleY = .1f;
    private float scaleZ = .1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        alterPSone();
        alterPStwo();
        alterPSthree();
	}

    public void alterPSone()
    {
        /********************
         * Emission Changes *
         *******************/
        //Make reference to the emission of Particle System 01 in Modded_fire_inhale
        var rate = PSone.emission;
        //Increase the rate over time.
        rate.rateOverTime = EMrate+=0.01f;

        /*****************
         * Scale Changes * 
         ****************/
        //Gradually Change the size of the Particles
        if (scaleX <= maxScale)
        {
            PSone.transform.localScale = new Vector3(scaleX += 0.001f, scaleY += 0.001f, scaleZ += 0.001f);
        }
    }

    public void alterPStwo()
    {
        var rate = PStwo.emission;
        //Can just set equal to EMrate since this is already changing in alterPSone()
        rate.rateOverTime = EMrate;
        //Can just set equal to scaleX,scaleY,scaleZ since this is already changing in alterPSone()
        PStwo.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }

    public void alterPSthree()
    {
        var rate = PSthree.emission;
        rate.rateOverTime = EMrate;
        PSthree.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}
