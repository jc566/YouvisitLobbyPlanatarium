using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JupiterFunFacts : MonoBehaviour {

    //Array of Strings that will contain the fun facts for jupiter.The order does not change here.
    public string[] funFactsArray;
	// a refrence to the robot for script assignment
	public Robot_AI helper;
	// the text field's parent object, including the bg
	public GameObject speech;
	// the text specifically needs a refrence
	public Text text;
    //Dynmically changing list to pick facts from. Copied values from funFactsArray.
    public List<string> funFacts;
    //number that lets us know when the funFacts List should be reset
    public int resetCounter;
	public GameObject wires;
	public GameObject basefield;

    public Planet_Move planet;

    public Robot_AI robot;

    public RobotButtons buttons;
    //Reference to the popWindowOver script to change the text value

    // Use this for initialization
    void Start () {
        //reference the PopWindowOver script attached to this object
   

        //start the process that creates array and list according.
        initliazeFactValues();
        
        //Run pick_a_random_fact to give a initial value for text_content on Jupiter
        pick_first_fact();
	}
	
	// Update is called once per frame
	void Update () {
		if(resetCounter > 0)
        {
            //Debug.Log("WE ARE GOOD");
        }
        else
        {
            //Debug.Log("WE ARE NOT GOOD");
            initliazeFactValues();
        }
	}
    /************************************************************************
     * This function does the following :                                   *
     * 1. Create the array of strings that are the facts.                   *
     * 2. Sets the resetCounter to the size/length of the facts array.      *
     * 3. Copies the values of the array into a List for dynamic resizing.  *
     ***********************************************************************/
    public void initliazeFactValues()
    {
        //initialize the string array and its values
        funFactsArray = new string[]
        {
            //This region of strings is changed for each planets individual version of this script.
            "Jupiter: \nHas the mass of 318 Earths!",
            "Jupiter: \nHas 67 Moons!",
			"Jupiter: \nJupiter has a Equatorial Diameter \nof 142,984 Km!",
			"Jupiter: \nOnly the Sun, Moon and Venus are \nbrighter. It is one of five planets visible to the naked eye from Earth.",
			"Jupiter: \nThe ancient Babylonians were the \nfirst to record their sightings of Jupiter.",
			"Jupiter: \nJupiter has the shortest day of \nall the planets.Only 9 hours and 55 minutes long.",
			"Jupiter: \nJupiter orbits the Sun once \nevery 11.8 Earth years.",
			"Jupiter: \nJupiter’s interior is made of \nrock, metal, and hydrogen compounds.",
            "Jupiter: \nJupiter has a thin ring system.",
			"Jupiter: \nJupiter orbits the Sun \nonce every 11.8 Earth years."

        };

        //set resetcounter equal to the size of the entire array
        resetCounter = funFactsArray.Length;

        //inject these string values into a list for purpose of "popping" them out
        for (int i = 0; i < funFactsArray.Length; i++)
        {
            funFacts.Add(funFactsArray[i]);
        }
    }
    /********************************************************************************************
     * Due to popoverwindow requiring an inital string, this function randomly picks a fact.    *
     * HOWEVER, it does not remove from the List of facts to display.                           *
     * So there will be one repeating fact before the reset.                                    *
     *******************************************************************************************/
    public void pick_first_fact()
    {
        //get a random index to choose from the list of strings
        int rand = Random.Range(0, funFacts.Count);
        //set the text content of popoverwindow script to be a randomly selected fact

    }
    /************************************************************************************
     * This function chooses a random fact from the dynamic List of facts.              *
     * After displaying a fact using popoverwindow script attached to the gameobject,   *
     * it removes it from the list of available facts.                                  *
     * The list will reset once resetCounter hits 0.                                    *
     ***********************************************************************************/
    public void pick_a_random_fact()
    {
		if(helper.inAnim ==false && planet.clicked == true)
        {
			wires.transform.localScale = new Vector3( 30,150,125 ) ;
			basefield.transform.localScale = new Vector3( 30,150,125 );
			resetCounter--;
			//get a random index to choose from the list of strings
			int rand = Random.Range(0, funFacts.Count);
			//set the text content of popoverwindow script to be a randomly selected fact
			// popUpRef.text_content = funFacts[rand];
			speech.SetActive ( true);
			text.text = funFacts[rand];
			//Debug.Log(funFacts[rand]);
			//Debug.Log(funFacts.Count);
			//remove the recently displayed fact from the list
			funFacts.Remove(funFacts[rand]);
            buttons.planeHologram.GetComponent<Animator>().Play("Opening_Dialog_Plane");
            buttons.currentColor = 0;
            robot.button = 4;
            for (int j = 0; j < buttons.buttons.Length; j++)
            {

                //Sets the emission color of all unselected objects to black
                buttons.buttons[j].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

            }
            buttons.selectedButton = -1;
        }
        else if (helper.inAnim == true)
        {
            return;
        }
        else
        {
            speech.SetActive(false);

            robot.button = 4;
            for (int j = 0; j < buttons.buttons.Length; j++)
            {

                //Sets the emission color of all unselected objects to black
                buttons.buttons[j].GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);

            }
            buttons.selectedButton = -1;

            buttons.planeHologram.GetComponent<Animator>().Play("Closing_Dialog_Plane");
            //Set current color to the dim green color
            buttons.currentColor = 0;


        }
    }
}
