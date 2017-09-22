using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAI : MonoBehaviour {

    // Use this for initialization


    public const int state_idle = 0;
    public const int state_interact = 1;

    public static int state;

    // other states to use only can think of two right now
    public const int state_interact2 = 2;

    public const int state_mute = 3;

    public const int state_display = 4;

    public const int state_skip = 5;

    public const int state_previous = 6;

    public Animation anim;

    public Animator animu;






    public AudioSource radio;


    public AudioClip[] songs;

    public AudioClip curretnsong;


    int i;

    bool muted;





    [SerializeField]
    private string title = "My Window";
    [SerializeField]
    private static float windowWidth = 200f;
    [SerializeField]
    private static float windowHeight = 250f;
    [SerializeField]
    private string text = "This is the text Area";

    public GUIStyle textStyle;

    private Rect windowRect = new Rect(Screen.width / 2, Screen.height / 2, windowWidth, windowHeight);
    // Use this for initialization
    private bool gazeOver = false;












    void Start () {

        state = 0;

        anim = GetComponent<Animation>();


        i = 0;

        radio.clip = songs[i];

        curretnsong = songs[i];
        radio.Play();

        muted = true;

    }
	
	// Update is called once per frame
	void Update () {

        windowRect.x = (Screen.width - windowWidth) / 2;
        windowRect.y = (Screen.height - windowHeight) / 2 - Screen.height * 0.3f;

        switch (state)
        {
            case state_idle:
                Idle();
                break;
            case state_interact:
                Interact();
                break;
            case state_mute:
                Mute();
                break;
            case state_display:
                Display();
                break;
            case state_skip:
                SkipSong();
                break;
            case state_previous:
                PreviousSong();
                break;


        }

	}



    void Idle()
    {
        // In this state the robot will be ideling floating around the character and doing idle animations this state will break once the player starts interacting with the robot

        //psudo code to go to the interact state
        /*
         * 
         * if(player clicks on robot)
         * {
         * 
         * state = state_interact
         * 
         * 
         * }
         */
        anim["test_anim"].speed = 1;


        gazeOver = false;



    }

    void Interact()
    {
        //this state will trigger once the player interacts with the robot 
        //this state will lead to the interactions the robot can do such as change music, display certain things etc.
        //will probably have the next state picked out based on what the user clicks
        //for example if the user picks the mute button the next state will be mute music and then that state will return to the interact state until the player dismisses the robot to the idle state;



        anim["test_anim"].speed = 0;

       // gazeOver = false;
    }


    void Mute()
    {
        if (muted == true)
        {
            radio.volume = 0;
            muted = false;
            state = 1;
            return;
        }

        if (muted == false)
        {
            radio.volume = 1;
            muted = true;
            state = 1;
            return;
        }

        
    }

    void Display()
    {



        if (gazeOver == true)
        {
           // radio.volume = 0;
            gazeOver = false;
            state = 1;
            return;
        }

        if (gazeOver == false)
        {
           // radio.volume = 1;
            gazeOver = true;
            state = 1;
            return;
        }





    }

    void SkipSong()
    {

        i++;

        if (i > 4)
        {
            i = 0;
        }
        radio.clip = songs[i];
        curretnsong = songs[i];
        radio.Play();
        state = 1;

    }

    void PreviousSong()
    {

        i--;

        if (i < 0)
        {
            i = 4;
        }
        radio.clip = songs[i];
        curretnsong = songs[i];
        radio.Play();

        state = 1;

    }

    void OnGUI()
    {
        if (gazeOver)  //Draw window if this is true;
            windowRect = GUI.Window(0, windowRect, DoMyWindow, title);
    }
    void DoMyWindow(int windowID)
    {
        //The component of the window.
        GUI.TextField(new Rect(20, 30, (windowWidth - (0.2f * windowWidth)), (windowHeight - (0.5f * windowHeight))), text, textStyle);
    }


    public void test()
    {
        state = 1;
        //  Debug.Log("ROBOT");

        //anim["Anim1"].speed = 0;
       // transform.gameObject.anim["test_anim"].speed = 0;
    }
    public void test2()
    {
        state = 0;
    }
    public void test3()
    {
        state = 3;
    }
    public void test4()
    {
        state = 4;
    }
}
