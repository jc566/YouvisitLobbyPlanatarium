using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***************************************************************************************
 * This Scripts purpose is to fine tune the features of the Blackhole Particle System. *
 **************************************************************************************/
public class Modded_Blackhole : MonoBehaviour {

    //variable that is in control of how big to make the particle system
    public float BlackHoleSizeMultipliter;

    //reference the parent game object for the blackhole particle system
    public GameObject blackhole;

    //reference to the 2 smaller particle systems attached to this parent object
    public ParticleSystem[] BHps;

    //rate at which particle system will grow
    public Vector3 growthIncrement;

    //reference to the max size it will grow to
    public Vector3 maxSize;

    //reference to how large the X can grow
    public float maxGrowth;
    //Boolean to control growth
    public bool isMaxSize = false;

    //Time interval to trigger Invoke
    public float invokeTimeInterval;

    // Use this for initialization
    void Awake () {
        //declare that the particle systems transform size will be X times bigger
        BlackHoleSizeMultipliter = 2.0f;

        //find the references of the parent object for blackhole
        blackhole = GameObject.Find("BlackHolePos");
        //link up the particle systems that are the children object
        BHps = blackhole.GetComponentsInChildren<ParticleSystem>();

        //set up the maxSize limit
        maxSize = new Vector3(BHps[0].transform.localScale.x * BlackHoleSizeMultipliter, BHps[0].transform.localScale.y * BlackHoleSizeMultipliter, BHps[0].transform.localScale.z * BlackHoleSizeMultipliter);

        //determine the float value to compare for max growth
        maxGrowth = BHps[0].transform.localScale.x * BlackHoleSizeMultipliter;

        //turn off the particle systems by default
        //BHps[0].Stop();
        //BHps[1].Stop();

        //From start, keep growing size of object
        //InvokeRepeating("increaseOverTime", 0, invokeTimeInterval);
        StartCoroutine("startBlackholeLogix");
    }
	
	// Update is called once per frame
	void Update () {
        //if the item grows to the max size, stop the growth script.
        if (BHps[0].transform.localScale.x >= maxGrowth)
        {
            StopAllCoroutines();
            CancelInvoke();
            isMaxSize = true;
        }
    }

    IEnumerator startBlackholeLogix()
    {
        if(!isMaxSize)
        {
            InvokeRepeating("increaseOverTime", 0, invokeTimeInterval);
            yield return new WaitForSeconds(0.01f);
        }
        else
        {
            yield return new WaitForSeconds(0.01f);
        }
    }

    //increase the particle systems size over time
    public void increaseOverTime()
    {
        for(int i = 0; i < BHps.Length;i++)
        {
            BHps[i].transform.localScale += growthIncrement;
        }
    }

    //function that turns the particle systems back ON
    public void turnOnPS()
    {
        BHps[0].Play();
        BHps[1].Play();
    }
    //function that turns the particle systems OFF
    public void turnOffPS()
    {
        BHps[0].Stop();
        BHps[1].Stop();
    }
}
