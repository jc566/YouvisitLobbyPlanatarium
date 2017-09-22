using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySunPS : MonoBehaviour {

    public ParticleSystem supernovaBlast; //reference to supernova Blast Particle System
    public ParticleSystem supernovaBurst; //reference to supernova Burst Particle System
	// Use this for initialization
	void Start () {

        //link up the particle systems accordingly
        supernovaBlast = GameObject.Find("supernovaBlast").GetComponentInChildren<ParticleSystem>();
        supernovaBurst = GameObject.Find("supernovaBurst").GetComponentInChildren<ParticleSystem>();

        //turn off the particle systems at the start by default
        supernovaBlast.Stop();
        supernovaBurst.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /********************************************************************
     * function that plays supernova blast,                             *
     * then waits for 5 seconds or the duration of the supernova blast  *
     * finally, it plays supernova burst.                               *
     *******************************************************************/
    public IEnumerator playSunsPS()
    {
        Debug.Log("Playing Blast");
        playSupernovaBlast();
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Playing Burst");
        playSupernovaBurst();
    }
    //function to play supernova blast PS
    public void playSupernovaBlast()
    {
        supernovaBlast.Play();
    }
    //function to play supernova burst PS
    public void playSupernovaBurst()
    {
        supernovaBlast.Stop();//stop the supernova blast just in case it exceeds 5 seconds
        supernovaBurst.Play();
    }
}
