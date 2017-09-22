using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot_AI : MonoBehaviour {

    // Use this for initialization

    //reference to the robot sound effects that will be played
    public AudioClip roboSound01;
    public AudioClip roboSound02;
    //reference to the robots audiosource
    public AudioSource roboAudioSource;
	//refrence to the robot's speech parent object
	public GameObject speech;
	//Reference to the hologram plane
	public GameObject planeHologram;
	//another bool for setting the tutorial this and inAim work in unison to create a switch
	public bool tutorial;

    int i;
	public bool inAnim = true;
    public bool muted;

    public bool gazeOver = false;


	public int talk;
	public string[] dialouge;
    
	public bool focus;

    public float battery_lvl;

    public float signal_strength;

    public int content_loaded;

    

	public float timer = 0;
    public GameObject eyes;

    public GameObject antenna;
	public GameObject wires;
	public GameObject basefield;

    public Material[] mats;

    public Material[] bat_mats;

    Renderer rend;
    Renderer antrend;

    public Canvas newCanva;
    //public GameObject Canva_location;
    public string text_content;

    public string text_start;

    //public Font newFont;

    public Text textarea;

	public Animator anim;

    public int button;


	public void setfoucOn(){

		focus = true;

	}

	public void setfoucOff(){

		focus = false;

	}

    void Start () {
        //link the reference to the robots audiosource
        roboAudioSource = this.GetComponent<AudioSource>();

        button = 4;

		dialouge = new string[4];

		dialouge [0] = "Hi! I’m so glad you could make it. \nWelcome to the Solar System!";
		dialouge [1] = "I will be your \nExtraterrestrial Galactic Guide! \nBut you can call me EGG :)";
		dialouge [2] = "Take a look around, there’s lots to see! \nKeep an eye out for the\n planets and the constellations. \nCan you find them all?";
		dialouge [3] = "And don’t worry about \nrunning out of battery or signal\n just tap the buttons on \nmy belly to look at your status!";

        text_start = "";
        i = 0;

		talk = -1;
        anim.Play("Armature|Float_toward_Player", -1, 0f);


        muted = true;

        rend = eyes.GetComponent<Renderer>();

        antrend = antenna.GetComponent<Renderer>();

        battery_lvl = this.gameObject.GetComponent<BatteryLife>().batteryLevel;

        signal_strength = 100;

        content_loaded = 0;
        newCanva.gameObject.SetActive(false);

        //trigger the robot sounds to play every 20 seconds.
        InvokeRepeating("playRobotSounds",5.0f, 20.0f);

    }

	void tutorialStart()
	{
	
		//Reference to the hologram plane
		//Open hologram plane
		planeHologram.GetComponent<Animator>().Play("Opening_Dialog_Plane");
		text_content = "Hey there!\n Play with my buttons!\n You'll learn about our planets.";
		wires.transform.localScale = new Vector3( 19,117,125 ) ;
		basefield.transform.localScale = new Vector3( 19,117,125 );
		textarea.text = text_content;
		speech.SetActive (true);
		tutorial = true;
	
	}
    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;




		if (timer >= 8.0f) {
			inAnim = false;
			gameObject.transform.localPosition= new Vector3 (3.33f, 0.60f,8.3f); //this line keeps the robot from sinking after its opening animation. Also starts the tutorial
            //gameObject.transform.eulerAngles = new Vector3(-21.204f, -88.697f, 25.832f); //sets the robot rotation
        } 

		if (inAnim == false && tutorial == false) {
			tutorialStart ();
		}

        if(battery_lvl < 20)
        {
            Low_Battery();
        }

        if(signal_strength < 50 && signal_strength > 0)
        {
            Bad_Signal();
        }

        else if(signal_strength <=0)
        {
            No_Signal();
        }

        if(content_loaded >= 100)
        {
            Content_Loaded();
        }

        
        if(content_loaded >= 100 && battery_lvl < 20 && signal_strength < 50 && signal_strength > 0 && signal_strength <= 0)
        {
            Low_Battery();
        }

        else if(content_loaded >= 100  && signal_strength < 50 && signal_strength > 0 && signal_strength <= 0)
        {
            Content_Loaded();
        }


        if (content_loaded >= 100 && battery_lvl < 20)
        {
            Low_Battery();
        }
        else if (content_loaded >= 100 && signal_strength < 50)
        {
            Content_Loaded();
        }
        else if(battery_lvl < 20 && signal_strength < 50)
        {
            Low_Battery();
        }


        if (battery_lvl > 20 && signal_strength > 50 && content_loaded < 100)
        {
            Default_Eyes();
        }
        
       





        //this is to test the battery,signal, and content functions will be removed once a way to determine those things is made


        if(Input.GetKey("o"))
        {
            battery_lvl--;
        }

        if (Input.GetKey("p"))
        {
            battery_lvl++;
        }


        if (Input.GetKey("k"))
        {
            signal_strength--;
        }

        if (Input.GetKey("l"))
        {
            signal_strength++;
        }


        if (Input.GetKey("u"))
        {
            content_loaded--;
        }

        if (Input.GetKey("i"))
        {
            content_loaded++;
        }





        //!audioSource.isPlaying

        



        //Check the Current Battery Life
        BatteryCheck();








    }



    public void Idle()
    {
        //play idle animation`  1
        anim.speed = 1;
        //gazeOver = false;
    }

    public void Interact()
    {
        //Debug.Log("HEre");
		if (!inAnim) {
			anim.speed = 0.0f;
		}
        //will stop the idle animation from playing
    }

    void Default_Eyes()
    {
        rend.sharedMaterial = mats[4];
    }

    void Low_Battery()
    {
        rend.sharedMaterial = mats[0];
    }

    void Bad_Signal()
    {
        rend.sharedMaterial = mats[1];
    }

    void No_Signal()
    {
        rend.sharedMaterial = mats[2];
    }

    void Content_Loaded()
    {
       // rend.sharedMaterial = mats[5];
        rend.sharedMaterial = mats[3];

    }
    /*
    public void Mute()
    {


       
        if (muted == true)
        {
            radio.volume = 0;
            muted = false;
           
            return;
        }

        if (muted == false)
        {
            radio.volume = 1;
            muted = true;
            
            return;
        }


    }
    */

    /**********************************************
     * Function that plays sound effects          *
     *********************************************/
    public void playRobotSounds()
    {
        roboAudioSource.clip = roboSound02;
        //play the sound clip periodically
        roboAudioSource.Play();
       
        
    }
    public void stopAllAudio()
    {
        //stop whatever sound effect played last
        roboAudioSource.Stop();
    }
    public void Display_Bat()
    {



        if(button == 3)
        {
            button = 4;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if(button != 3)
        {

            button = 3;
            text_content = "Your battery level is " + battery_lvl + "%";
            wires.transform.localScale = new Vector3(19, 96, 125);
            basefield.transform.localScale = new Vector3(19, 96, 125);
            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;


        }

  


        /*
        if (gazeOver == true && !string.IsNullOrEmpty(text_content) && button == 1)
        {
            button = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == true && !string.IsNullOrEmpty(text_content))
        {

            button = 1;
			text_content = "Your battery level is " + battery_lvl + "%";
			wires.transform.localScale = new Vector3( 19,96,125 ) ;
			basefield.transform.localScale = new Vector3( 19,96,125 );
			textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;

        }
        else if (gazeOver == true)
        {
            button = 0;
            // Debug.Log("Turnoff text");
            // radio.volume = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == false)
        {
            button = 1;
            // radio.volume = 1;
            //Debug.Log("text on");
            text_content = "Your battery level is " + battery_lvl;

            textarea.text = text_content;
           
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;
        }
        */
     
    }
    public void Content_Load()
    {



        if (button == 1)
        {
            button = 4;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (button != 1)
        {

            button = 1;
            text_content = "amount of content loaded:" + content_loaded;
            wires.transform.localScale = new Vector3(19, 122, 125);
            basefield.transform.localScale = new Vector3(19, 122, 125);
            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;


        }




        /*

        if (gazeOver == true && !string.IsNullOrEmpty(text_content) && button == 2)
        {
            button = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }
        else if (gazeOver == true && !string.IsNullOrEmpty(text_content))
        {

            button = 2;
			text_content = "amount of content loaded:" + content_loaded;
			wires.transform.localScale = new Vector3( 19,122,125 ) ;
			basefield.transform.localScale = new Vector3( 19,122,125 );
			textarea.text = text_content;
            
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;

        }

        else if (gazeOver == true)
        {
            // Debug.Log("Turnoff text");
            // radio.volume = 0;
           // button = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == false)
        {
            // radio.volume = 1;
            //Debug.Log("text on");

            


            button = 2;
            text_content = "amount of content loaded: " + content_loaded;

            textarea.text = text_content;
            
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;
        }
        */


    }
    public void Signal_Strength()
    {



        if (button == 0)
        {
            button = 4;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (button != 0)
        {

            button = 0;
            text_content = "Your signal is " + signal_strength;
            wires.transform.localScale = new Vector3(19, 62, 125);
            basefield.transform.localScale = new Vector3(19, 62, 125);
            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;


        }

        /*
        if (gazeOver == true && !string.IsNullOrEmpty(text_content) && button == 3)
        {
            button = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == true && !string.IsNullOrEmpty(text_content))
        {

            button = 3;
			text_content = "Your signal is " + signal_strength;
			wires.transform.localScale = new Vector3( 19,62,125 ) ;
			basefield.transform.localScale = new Vector3( 19,62,125 );
			textarea.text = text_content;
            //text_content = "Your signal is " + signal_strength;

            // textarea.text = text_content;

            
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;

        }

        else if (gazeOver == true)
        {
            button = 0;
            // Debug.Log("Turnoff text");
            // radio.volume = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == false)
        {
            // radio.volume = 1;
            //Debug.Log("text on");

            

            button = 3;
            text_content = "Your signal is " + signal_strength;

            textarea.text = text_content;

           
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;
        }

        */

    }

    public void Display()
    {





        if (button == 2)
        {
            button = 4;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (button != 2)
        {

            button = 2;
            talk += 1;
            if (talk > 3)
            {
                talk = 0;
            }
            if (!focus)
            {
                text_content = dialouge[talk];
            }
            switch (talk)
            {

                case 0:

                    wires.transform.localScale = new Vector3(22, 135, 125);
                    basefield.transform.localScale = new Vector3(22, 132, 125);
                    break;

                case 1:

                    wires.transform.localScale = new Vector3(22, 135, 125);
                    basefield.transform.localScale = new Vector3(22, 132, 125);
                    break;

                case 2:
                    wires.transform.localScale = new Vector3(26, 146, 125);
                    basefield.transform.localScale = new Vector3(26, 150, 125);
                    break;


                case 3:

                    wires.transform.localScale = new Vector3(26, 146, 125);
                    basefield.transform.localScale = new Vector3(26, 150, 125);
                    break;

            }



            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;


        }
        // Debug.Log("Display");
        /*
        if (gazeOver == true && !string.IsNullOrEmpty(text_content) && button == 4)
        {
            button = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == true && !string.IsNullOrEmpty(text_content))
        {

            button = 4;
            //text_content = "Your signal is " + signal_strength;

            // textarea.text = text_content;

            
            talk += 1;
            if (talk > 3)
            {
                talk = 0;
            }
			if (!focus) {
				text_content = dialouge [talk];
			}
			switch (talk){

			case 0:
				
				wires.transform.localScale = new Vector3( 22,135,125 ) ;
				basefield.transform.localScale = new Vector3( 22,132,125 );
				break;

			case 1 :
				
				wires.transform.localScale = new Vector3( 22,135,125 ) ;
				basefield.transform.localScale = new Vector3( 22,132,125 );
				break;

			case 2 :
				wires.transform.localScale = new Vector3( 26,146,125 ) ;
				basefield.transform.localScale = new Vector3( 26,150,125 );
				break;


			case 3 :

				wires.transform.localScale = new Vector3( 26,146,125 ) ;
				basefield.transform.localScale = new Vector3( 26,150,125 );
				break;

			}



            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
            gazeOver = true;

            return;

        }
       else if (gazeOver == true)
        {
            button = 0;
            // Debug.Log("Turnoff text");
            // radio.volume = 0;
            newCanva.gameObject.SetActive(false);
            gazeOver = false;
            return;
        }

        else if (gazeOver == false)
        {
            // radio.volume = 1;
            //Debug.Log("text on");

            //text_content = "Your signal is " + signal_strength;
            button = 4;


			talk += 1;
			if (talk > 3) 
			{
				talk = 0;
			}
			if (!focus) {
				text_content = dialouge [talk];
			}
			wires.transform.localScale = new Vector3( 22,122,125 ) ;
			basefield.transform.localScale = new Vector3( 22,122,125 );



            textarea.text = text_content;
            
            newCanva.gameObject.SetActive(true);
            gazeOver = true;
           
            return;
        }

        */
    }



    public void BatteryCheck()
    {
        //check the CURRENT battery life
        battery_lvl = this.gameObject.GetComponent<BatteryLife>().getBatteryLevel();
        if(battery_lvl > 60)
        {
            antrend.sharedMaterial = bat_mats[0];
        }

        else if (battery_lvl < 60 && battery_lvl > 20)
        {
            antrend.sharedMaterial = bat_mats[1];
        }
        if (battery_lvl < 20)
        {
            antrend.sharedMaterial = bat_mats[2];
        }
    }
    /*
    public void SkipSong()
    {

        i++;

        if (i > 4)
        {
            i = 0;
        }
        radio.clip = songs[i];
        curretnsong = songs[i];
        radio.Play();
        

    }
    
    public void PreviousSong()
    {

        i--;

        if (i < 0)
        {
            i = 4;
        }
        radio.clip = songs[i];
        curretnsong = songs[i];
        radio.Play();

      

    }
    */

}
