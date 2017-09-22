using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthFunFacts : MonoBehaviour {

    //Array of Strings that will contain the fun facts for jupiter.The order does not change here.
    public string[] funFactsArray;
    //Dynmically changing list to pick facts from. Copied values from funFactsArray.
    public List<string> funFacts;
    //number that lets us know when the funFacts List should be reset
    public int resetCounter;
    //Reference to the popWindowOver script to change the text value
    public PopWindowOver popUpRef;

    // Use this for initialization
    void Start()
    {
        //reference the PopWindowOver script attached to this object
        popUpRef = this.gameObject.GetComponent<PopWindowOver>();

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
            Debug.Log("WE ARE GOOD");
        }
        else
        {
            Debug.Log("WE ARE NOT GOOD");
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
            "Earth: \nHas a mass of 5.97 x 10^24 kg",
            "Earth: \nEarth has a powerful magnetic field.This field protects the Earth from the effects of solar wind.",
            "Earth: \nEarth is the only planet not named after a Greek/Roman god.",
            "Earth: \nThe Earth is the densest planet in the Solar System.",
            "Earth: \nIt is the only planet that has an atmosphere containing 21 percent oxygen.",
            "Earth: \nThe planets closer to the Sun, Mercury and Venus, have shorter years than the Earth. The planets further away from the Sun have longer years.",
            "Earth: \nAnnually, Earth days amount to 365.24 days.Hence, the leap day every 4 years.",
            "Earth: \nIt's Diameter from the Equator is 12,756 km",
            "Earth: \nThe Earth is home to over 7.5 Billion human beings.",
            "Earth: \nThe name 'Earth' is derived from both English and German words, 'eor(th)e/ertha' and 'erde', respectively, which mean ground."

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
        popUpRef.text_content = funFacts[rand];
    }
    /************************************************************************************
     * This function chooses a random fact from the dynamic List of facts.              *
     * After displaying a fact using popoverwindow script attached to the gameobject,   *
     * it removes it from the list of available facts.                                  *
     * The list will reset once resetCounter hits 0.                                    *
     ***********************************************************************************/
    public void pick_a_random_fact()
    {
        resetCounter--;
        //get a random index to choose from the list of strings
        int rand = Random.Range(0, funFacts.Count);
        //set the text content of popoverwindow script to be a randomly selected fact
        popUpRef.text_content = funFacts[rand];

        //Debug.Log(funFacts[rand]);
        //Debug.Log(funFacts.Count);

        //remove the recently displayed fact from the list
        funFacts.Remove(funFacts[rand]);
    }
}
