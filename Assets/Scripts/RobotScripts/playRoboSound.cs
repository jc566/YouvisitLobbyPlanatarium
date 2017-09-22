using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRoboSound : MonoBehaviour {
    //reference to the robot sound effects that will be played
    public AudioSource audio;
    public AudioClip roboSound01;
	// Use this for initialization
	void Start () {
        //link the reference to the robots audiosource
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSoundWhenButtonClicked()
    {
        
        //play sound clip when a button is interacted with
        audio.PlayOneShot(roboSound01, 1.0f);

    }
}
