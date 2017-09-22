using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRotateScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateScreen();
	}
    public void RotateScreen()
    {
        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
