using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour {

    //Declare the max growth size
    public float maxGrowth = 1.0f;
    //Declare the growth increment
    public Vector3 growthIncrement;
    //Boolean to control growth
    public bool isMaxSize = false;
    //Time interval to trigger Invoke
    public float invokeTimeInterval;
    
	// Use this for initialization
	void Start () {
        //From start, keep growing size of object
        InvokeRepeating("increaseSize", 0, invokeTimeInterval);
	}
	
	// Update is called once per frame
	void Update () {
        
        //if the item grows to the max size, stop the growth script.
        if(transform.localScale.x >= maxGrowth)
        {
            CancelInvoke();
            isMaxSize = true;
        }
	}

    //Increase the size of object
    public void increaseSize()
    {
        this.transform.localScale += growthIncrement;

    }
}
