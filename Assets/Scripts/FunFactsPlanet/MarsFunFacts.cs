using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MarsFunFacts : MonoBehaviour {

	bool enabled = false;
    //Array of Strings that will contain the fun facts for jupiter.The order does not change here.
    public string[] funFactsArray;
	// a refrence to the robot for script assignment
	public Robot_AI helper;
	//Dynmically changing list to pick facts from. Copied values from funFactsArray.
    public List<string> funFacts;
    //number that lets us know when the funFacts List should be reset
    public int resetCounter;
    //Reference to the popWindowOver script to change the text value
   // public PopWindowOver popUpRef;
	// the text field's parent object, including the bg
	public GameObject speech;
	// the text specifically needs a refrence
	public Text text;
	public GameObject wires;
	public GameObject basefield;

    public Planet_Move planet;

    public Robot_AI robot;

    public RobotButtons buttons;
    // Use this for initialization
    void Start()
    {
        //reference the PopWindowOver script attached to this object
      //  popUpRef = this.gameObject.GetComponent<PopWindowOver>();

        //start the process that creates array and list according.
        initliazeFactValues();

        //Run pick_a_random_fact to give a initial value for text_content on Jupiter
        pick_first_fact();
    }

    // Update is called once per frame
    void Update()
    {
        if (resetCounter > 0)
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
            "Mars: \nHas a mass 10.7% of Earth",
            "Mars: \nHas 2 Moons; Phobos and Deimos.",
            "Mars: \nHas a Equatorial Diameter of 6,792 Km!",
			"Mars: \nMars and Earth have \napproximately the \nsame land mass.",
			"Mars: \nMars is home to the \ntallest mountain in\n the Solar System called Olympus Mons.",
			"Mars: \nHas the largest Dust Storms\n in the Solar System.",
			"Mars: \nTakes its name from the \nRoman god of War.",
            "Mars: \nThere are signs of liquid on Mars!",
            "Mars: \nOne day Mars will have a ring.",
			"Mars: \nMars was first recorded\n by Egyptian Astronomers."

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
       // popUpRef.text_content = funFacts[rand];
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
