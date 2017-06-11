using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingLight : MonoBehaviour {

    public Light supernovaLight;
    public float maxRange;

	// Use this for initialization
	void Start () {
        supernovaLight = this.gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        lightGrowth();
	}

    void lightGrowth()
    {
        if (supernovaLight.range <= maxRange)
        {
            supernovaLight.range += .02f;
        }
    }
}
