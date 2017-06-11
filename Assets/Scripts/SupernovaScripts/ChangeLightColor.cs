using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour {

    public Light supernovaColor; //make reference to the supernovas light

    public Color[] supernovaPhases; //list of colors for the supernova to change colors to
	// Use this for initialization
	void Start () {
        supernovaColor = this.GetComponent<Light>();

        //Create and Populate list of colors to change into
        supernovaPhases = new Color[7];

        supernovaPhases[0] = Color.red;                     //red  
        supernovaPhases[1] = new Color32(255,142,0,255);    //orange
        supernovaPhases[2] = Color.yellow;                  //yellow
        supernovaPhases[3] = new Color32(139,146,20,255);   //yellow-white
        supernovaPhases[4] = Color.white;                   //white
        supernovaPhases[5] = new Color32(11,13,62,255);     //blue-white
        supernovaPhases[6] = Color.blue;                    //blue

        //Start the Coroutine handling color change
        StartCoroutine("changeColor");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator changeColor()
    {
        
        for (int i = 0; i < 7; i++)
        {
            //Wait for a time
            yield return new WaitForSeconds(2.0f);
            //Make it Red
            supernovaColor.color = supernovaPhases[i];
            //Wait for a time
            //yield return new WaitForSeconds(2.0f);
        }
    }

 
}
