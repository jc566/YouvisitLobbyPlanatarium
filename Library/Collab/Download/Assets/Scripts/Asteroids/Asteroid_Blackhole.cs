using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Blackhole : MonoBehaviour {

    public float moving = 1.0f;
    public float speed;
    //boolean to control whether or not the astroids should move
    bool isMoveToBH;

    public Transform blackhole;
    // Use this for initialization
    void Awake () {
        //link up the reference of the 'blackhole' position
        blackhole = GameObject.Find("Sun_2").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        //when its time to show blackhole, allow the asteroids to move
		if(isMoveToBH)
        {
            asteroidsToBlackhole();
        }
	}
    //grab all asteroid children and make then go towards the blackhole
    public void asteroidsToBlackhole()
    {
        foreach(Transform child in transform)
        {
            isMoveToBH = true;
            float step = speed * Time.deltaTime;
            child.transform.position = Vector3.MoveTowards(child.transform.position, blackhole.position, step);
            moving = 1.0f;
        }
    }
}
