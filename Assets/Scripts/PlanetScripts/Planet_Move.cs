using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Move : MonoBehaviour {

    // Use this for initialization
	public GameObject speech;
    public float speed;
	public float rot_speed;
    public GameObject viewpos;
	public revolve revolve;
    public GameObject orginalpos;
	public Vector3 origin = Vector3.zero;
    public GameObject camera_main;
	public bool needs_to_move = false;
	float moving = 1.0f;
    public bool clicked;

    static public GameObject planet;


    // Control controlscript = player.GetComponent<Control>();

    Planet_Move move_script;

    //reference to where the planet will be placed when blackhole is present
    public Transform blackhole;
    //boolean to control the moving of the planet to blackhole
    public bool moveToBH;

    void Awake () {
        clicked = false;
        speed = 300;
		rot_speed = revolve.speed;
		origin = orginalpos.transform.position;

        //link up the reference of the 'blackhole' position
        blackhole = GameObject.Find("Sun_2").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

		//moves the planet to the view position
		if (clicked == true) {
			
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, viewpos.transform.position, step);
			moving = 1.0f;
			needs_to_move = true;

		}
        //moves the planet to its orginal position
		if (clicked == false && needs_to_move == true) {
			float step = speed * Time.deltaTime;

			revolve.speed = rot_speed;
			origin = orginalpos.transform.position;
			transform.position = Vector3.MoveTowards (transform.position, origin , step);
			moving -= 1.0f * Time.deltaTime;		
			if (moving <= 0.0f) {
				needs_to_move = false;
			}
		}
        //moves the planet to the blackhole
        if(moveToBH)
        {
            clicked = false;
            movePlanetToBlackhole();
        }

	}
    //sets planets origin position
    public void SetOrigin()
    {
        
        origin = gameObject.transform.position;
  

    }


    //moves the planet to the view pos
    public void Move()
    {
        
        if (clicked == false)
        {
			speech.SetActive (false);
            //if the planet variable is null it sets the planet that was clicked to it and sets clicked to true which will trigger the if statement in the update function
            if(planet == null)
            {
                clicked = true;
              

                viewpos.transform.parent = null;

                planet = transform.gameObject;

                return;
            }
            //if the planet that was clicked does not equal the planet variable it will send the gameobject in the planet varibale to its orginal postion
            //and then this gameobject will become the planet variable to get moved to the view position
            if (planet != transform.gameObject)
            {
               


                move_script = planet.GetComponent<Planet_Move>();

                
                move_script.Move();

                clicked = true;
                

                viewpos.transform.parent = null;

               

                planet = transform.gameObject;

                return;

                

            }
            
           
        }
        //if the planet was already clicked it will send it back to orbit
        else if(clicked == true)
        {

            clicked = false;
           

            viewpos.transform.parent = camera_main.transform;

            planet = null;

            return;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        
    }

    //function that moves the planets into the blackhole
    public void movePlanetToBlackhole()
    {
        moveToBH = true;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, blackhole.position, step);
        moving = 1.0f;
    }

}
