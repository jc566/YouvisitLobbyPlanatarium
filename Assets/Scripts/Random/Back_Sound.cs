using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Sound : MonoBehaviour {

    // Use this for initialization

    public AudioSource radio;


    public AudioClip[] songs;

    public AudioClip curretnsong;
 
    int i;

    bool muted;
    void Start () {

        radio = this.gameObject.GetComponent<AudioSource>();

        i = 0;

        radio.clip = songs[i];

        curretnsong = songs[i];
        radio.Play();

        muted = true;
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown("d"))
        {
            SkipSong();
        }

        if(Input.GetKeyDown("a"))
        {

            PreviousSong();
        }
        if(Input.GetKeyDown("m"))
        {
            MuteSong();
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

    }

    void MuteSong()
    {
        if (muted == true)
        {
            radio.volume = 0;
            muted = false;
            return;
        }
            
        if(muted == false)
        {
            radio.volume = 1;
            muted = true;
            return;
        } 

    }

}
