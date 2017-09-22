using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SunPhaseColorChange : MonoBehaviour
{
    //reference to the globe object attached to the sun_2
    public GameObject globe;
    //reference to the Crown object attached to the sun_2
    public GameObject[] crown;


    public GameObject atmosphere;
    public GameObject atmosphere2;

    //reference to the PlaySunPS script
    public PlaySunPS sun;

    //reference to the lens flare
    public LensFlare lensFlare;

    //reference to the lens flare colors that sun will change into
    public Color[] supernovaPhases;

    //this is the list of materials to choose from to change colors for Sun aka Globe
    private Material[] listOfSunMats;
    //this is the list of materials to choose from to change colors for Glow effect aka Crown / Corona shader
    private Material[] listOfGlowMats;
    //this is the list of materials to choose from to change colors for Suns glow effect aka Atmoshpere2
    private Material[] listOfAtmoMats;
    //reference to the material "globe" can change into
    public Material sun_red;
    public Material sun_orange;
    public Material sun_yellow;
    public Material sun_yellow_white;
    public Material sun_white;
    public Material sun_blue_white;
    public Material sun_blue;
    //reference to the material "crown" can change into
    public Material crown_red;
    public Material crown_orange;
    public Material crown_yellow;
    public Material crown_yellow_white;
    public Material crown_white;
    public Material crown_blue_white;
    public Material crown_blue;

    //reference to the material "atmoshpere2" can change into
    public Material atmo_red;
    public Material atmo_orange;
    public Material atmo_yellow;
    public Material atmo_yellow_white;
    public Material atmo_white;
    public Material atmo_blue_white;
    public Material atmo_blue;

    //reference to blackhole
    public GameObject blackhole;
	public Material crown_blackhole;

    //boolean that determines the suns ability to be interacted with
    public bool isClicked;

    //reference for the 2nd ray cast that determines whether or not to toggle the reticle
    public rayCastScript raycastForDetection;

    //reference to all the planets in the scene
    public GameObject[] planets;
    //reference to all the asteroids in the scene
    public GameObject asteroids;
    //reference to all the constellations in the scene
    public GameObject[] constellations;

    //reference to get this current levels ID
    public int scene;

    // Use this for initialization
    void Awake()
    {
        //get the current levels ID
        scene = SceneManager.GetActiveScene().buildIndex;
        //by default the sun is not interactable
        isClicked = false;
        //link up to the "globe" aka Sun
        globe = GameObject.Find("Globe");
        //link up to the "crown" aka Sun Glow effect INCLUDING its children. All are linked via Tag "Crown"
        crown = GameObject.FindGameObjectsWithTag("Crown");
        //link to the atmoshpere objects to toggle off later
        atmosphere = GameObject.Find("Atmosphere");
        atmosphere2 = GameObject.Find("Atmosphere2");

        //link up to the raycast script that determines whether or not to toggle reticle on/off
        raycastForDetection = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<rayCastScript>();

        //link up the PlaySunPS to the proper script/object
        sun = this.gameObject.GetComponent<PlaySunPS>();

        //link up the lens Flare to change color to match suns phases
        lensFlare = this.gameObject.GetComponent<LensFlare>();

        //Declare the size of the material list arrays
        listOfSunMats = new Material[7];
        listOfGlowMats = new Material[7];
        listOfAtmoMats = new Material[7];

        //decalre the size of the planets array
        planets = new GameObject[9];
        //link up the reference to the asteroid field in scene
        asteroids = GameObject.Find("Asteroid_field");
        //declare the size of the constellations array
        constellations = new GameObject[8];

        //create the list of colors to choose from for both sun/glow affect aka Globe/Crown
        listOfSunMats[0] = sun_red;
        listOfGlowMats[0] = crown_red;
        listOfAtmoMats[0] = atmo_red;

        listOfSunMats[1] = sun_orange;
        listOfGlowMats[1] = crown_orange;
        listOfAtmoMats[1] = atmo_orange;

        listOfSunMats[2] = sun_yellow;
        listOfGlowMats[2] = crown_yellow;
        listOfAtmoMats[2] = atmo_yellow;

        listOfSunMats[3] = sun_yellow_white;
        listOfGlowMats[3] = crown_yellow_white;
        listOfAtmoMats[3] = atmo_yellow_white;

        listOfSunMats[4] = sun_white;
        listOfGlowMats[4] = crown_white;
        listOfAtmoMats[4] = atmo_white;

        listOfSunMats[5] = sun_blue_white;
        listOfGlowMats[5] = crown_blue_white;
        listOfAtmoMats[5] = atmo_blue_white;

        listOfSunMats[6] = sun_blue;
        listOfGlowMats[6] = crown_blue;
        listOfAtmoMats[6] = atmo_blue;

        //Create and Populate list of colors for the lens flare to change into
        supernovaPhases = new Color[7];

        supernovaPhases[0] = Color.red;                     //red  
        supernovaPhases[1] = new Color32(255, 142, 0, 255);    //orange
        supernovaPhases[2] = Color.yellow;                  //yellow
        supernovaPhases[3] = new Color32(139, 146, 20, 255);   //yellow-white
        supernovaPhases[4] = Color.white;                   //white
        supernovaPhases[5] = new Color32(11, 13, 62, 255);     //blue-white
        supernovaPhases[6] = Color.blue;                    //blue

        //set the initial colors to be RED
        globe.GetComponent<Renderer>().material = sun_red;
        atmosphere2.GetComponent<Renderer>().material = atmo_red;
        crown[0].GetComponent<Renderer>().material = crown_red;
        crown[1].GetComponent<Renderer>().material = crown_red;
        crown[2].GetComponent<Renderer>().material = crown_red;
        crown[3].GetComponent<Renderer>().material = crown_red;
        crown[4].GetComponent<Renderer>().material = crown_red;
        crown[5].GetComponent<Renderer>().material = crown_red;

        //set links up to the planets
        planets[0] = GameObject.Find("Planet_Mercury");
        planets[1] = GameObject.Find("Planet_Venus3");
        planets[2] = GameObject.Find("Planet_Earth_002");
        planets[3] = GameObject.Find("Planet_Mars_002");
        planets[4] = GameObject.Find("Planet_Jupiter_002");
        planets[5] = GameObject.Find("Planet_Saturn");
        planets[6] = GameObject.Find("Planet_Neptune");
        planets[7] = GameObject.Find("Uranus_002");
        planets[8] = GameObject.Find("Planet_Pluto");

        //set links up to the constellations
        constellations[0] = GameObject.Find("Pisces_Constellation");
        constellations[1] = GameObject.Find("Leo_Constellation");
        constellations[2] = GameObject.Find("Scorpio_Constellation");
        constellations[3] = GameObject.Find("Gemini_Constellation");
        constellations[4] = GameObject.Find("Libra_Constellation");
        constellations[5] = GameObject.Find("Youvisit_Constellation");
        constellations[6] = GameObject.Find("Aries_Constellation");
        constellations[7] = GameObject.Find("Taurus_Constellation");

        StartCoroutine("startSunPhases");
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    //This function handles what happens after the sun is able to be clicked and then clicked
    public void OnClickedDo()
    {
        //reload the Level
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        /***********************************************************************************
         *Below is the Manual reset attempt....                                            *
         *Manual Reset. Not used anymore but left in to show the hell in trying to do it.  *
         **********************************************************************************/
        //turn off the boolean for making the sun clickable
        //raycastForDetection.sunIsClickable = false;
        //turn off blackhole particle system in case of reset scenario
        //blackhole.GetComponent<Modded_Blackhole>().turnOffPS();
        //confirm that the globe and atmoshperes are enabled in case of reset scenario
        //atmosphere.SetActive(true);
        //atmosphere2.SetActive(true);
        //globe.SetActive(true);
        //turn the lens flare back on
        //lensFlare.enabled = true;

        //restart the suns logic upon being clicked
        //StartCoroutine("startSunPhases");


    }

    /// <summary>
    /// This ienumerator function basically controls the entire collection of phases the sun will undergo
    /// </summary>
    /// <returns></returns>
    IEnumerator startSunPhases()
    {
        //slight delay at start to allow for things to load/execute properly in case of reset scenario
        yield return new WaitForSeconds(2.1f);
        //Change all the items to the corresponding color in the list of materials. 
        //This includes the lens flare color changes.
        for (int i = 0; i < 7; i++)
        {
            globe.GetComponent<Renderer>().material = listOfSunMats[i];
            atmosphere2.GetComponent<Renderer>().material = listOfAtmoMats[i];
            crown[0].GetComponent<Renderer>().material = listOfGlowMats[i];
            crown[1].GetComponent<Renderer>().material = listOfGlowMats[i];
            crown[2].GetComponent<Renderer>().material = listOfGlowMats[i];
            crown[3].GetComponent<Renderer>().material = listOfGlowMats[i];
            crown[4].GetComponent<Renderer>().material = listOfGlowMats[i];
            crown[5].GetComponent<Renderer>().material = listOfGlowMats[i];
            lensFlare.color = supernovaPhases[i];
            //Wait for a time
            yield return new WaitForSeconds(10.0f);

        }
        Debug.Log("Will Start Playing PS effects now!");

        //play the supernova Particle systems for blast and burst after the color changes are finished
        sun.StartCoroutine("playSunsPS");

        yield return new WaitForSeconds(7.0f);

        //turn off all features to make our 'blackhole'
        atmosphere.SetActive(false);
        atmosphere2.SetActive(false);
        globe.SetActive(false);
		crown[0].GetComponent<Renderer>().material = crown_blackhole;
		crown[1].GetComponent<Renderer>().material = crown_blackhole;
		crown[2].GetComponent<Renderer>().material = crown_blackhole;
		crown[3].GetComponent<Renderer>().material = crown_blackhole;
		crown[4].GetComponent<Renderer>().material = crown_blackhole;
		crown[5].GetComponent<Renderer>().material = crown_blackhole;
        lensFlare.enabled = false;
        //set the blackhole particle systems to be true
        blackhole.SetActive(false);
        
        blackhole.SetActive(true);
        blackhole.GetComponent<Modded_Blackhole>().turnOffPS();
        blackhole.GetComponent<Modded_Blackhole>().turnOnPS();

        //make each planet go towards the blackhole with X seconds in between each one via SetActive(False)
        for (int i=0; i< planets.Length; i++)
        {
            planets[i].GetComponent<Planet_Move>().movePlanetToBlackhole();
            yield return new WaitForSeconds(1.3f);
            planets[i].SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        ////make each planet go towards the blackhole with X seconds in between each one via Renderer
        //for(int i = 0; i < planets.Length;i++)
        //{
        //    planets[i].GetComponent<Planet_Move>().movePlanetToBlackhole();
        //    yield return new WaitForSeconds(1.0f);

        //    //if the planet is EARTH, find the child item moon and disable renderer.
        //    if(planets[i].name == "Planet_Earth_002")
        //    {
        //        planets[i].gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        //    }
        //    //if the planet is SATURN, find the child item saturn_ring including its children and disable renderer.
        //    if (planets[i].name == "Planet_Saturn")
        //    {
        //        planets[i].gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        //        planets[i].gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<Renderer>().enabled = false;
        //    }
        //    planets[i].GetComponent<Renderer>().enabled = false;
        //}

        //make the astroids go towards the blackhole
        asteroids.GetComponent<Asteroid_Blackhole>().asteroidsToBlackhole();
        //add some time buffer between asteroids being absorbed by blackhole and constellations
        yield return new WaitForSeconds(1.0f);
        //make each constellation go towards the blackhole with X seconds in between each one
        for(int i=0;i < constellations.Length;i++)
        {
            constellations[i].GetComponent<Constellations_ToBlackhole>().MoveToBlackhole();
            yield return new WaitForSeconds(0.5f);
            constellations[i].SetActive(false);
        }
        //finally, set the boolean allowing the sun to be interactable to be true
        raycastForDetection.sunIsClickable = true;


        
    }
}
