using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotButtons : MonoBehaviour {
    public int currentColor;
    //The currently selected button
    public int selectedButton;
    //List containing all of the buttons
    public GameObject[] buttons;
    //Amount of time buttons remain lit during the flashing process
    public float glowDuration;
    //Amount of time buttons remain dim during the flashing process
    public float dimDuration;
    //Reference to the hologram plane
    public GameObject planeHologram;

	// Use this for initialization
	void Start ()
    {
        //-1 means that no button is currently selected
        selectedButton = -1;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
        StartCoroutine("Flash");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Called when a button is pressed, and sets the emission color of the buttons
    public void ActivateButton(int i)
    {
        //If pressed button is already activated, then deactivate it and close hologram plane
        if (selectedButton == i)
        {
            //Close hologram plane
            planeHologram.GetComponent<Animator>().Play("Closing_Dialog_Plane");
            //Set current color to the dim green color
            currentColor = 0;
            //Make all buttons flash again
            StartCoroutine("Flash");
            selectedButton = -1;
        }
        else
        {
            //Open hologram plane
            planeHologram.GetComponent<Animator>().Play("Opening_Dialog_Plane");
            currentColor = 0;
            //Sets the emission color of the selected button to green
            buttons[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            for (int j = 0; j < buttons.Length; j++)
            {
                if (j != i)
                {
                    //Sets the emission color of all unselected objects to black
                    buttons[j].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                }
            }
            //Stop buttons from flashing
            StopCoroutine("Flash");
            //Update currently selected button
            selectedButton = i;
        }
    }

    //Makes buttons flash when no button is pressed
    IEnumerator Flash()
    {
        for (;;)
        {
            //Loops through all of the buttons and sets their emission color to green 
            //for the amount specified in the glowDuration variable
            if (currentColor == 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
                }
                currentColor++;
                yield return new WaitForSeconds(glowDuration);
            }
            //Loops through all of the buttons and sets their emission color to black 
            //for the amount specified in the colorDuration variable
            else if (currentColor == 1)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                }
                currentColor--;
                yield return new WaitForSeconds(dimDuration);
            }
        }
    }
}
