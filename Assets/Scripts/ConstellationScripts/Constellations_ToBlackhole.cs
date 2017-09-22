using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellations_ToBlackhole : MonoBehaviour {

    public float moving = 1.0f;
    public float speed;
    //boolean to control whether or not the astroids should move
    bool isMoveToBH;
    //reference to the blackholes position, which is really the suns position. I know confusing....
    public Transform blackhole;

    // Use this for initialization
    void Start () {
        //link up the reference of the 'blackhole' position
        blackhole = GameObject.Find("Sun_2").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        //when its time to show blackhole, allow the asteroids to move
        if (isMoveToBH)
        {
            MoveToBlackhole();
        }
    }

    /****************************************************************************************************************
     * When the blackhole is ready, make the constellation this script is attached to move towards the blackhole.   *
     ***************************************************************************************************************/
    public void MoveToBlackhole()
    {
        foreach (Transform child in transform)
        {
            isMoveToBH = true;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, blackhole.position, step);
            moving = 1.0f;
        }
    }
}
