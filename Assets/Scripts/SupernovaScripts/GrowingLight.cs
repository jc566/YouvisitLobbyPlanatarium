using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingLight : MonoBehaviour {

    public Light supernovaLight;

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
        supernovaLight.range += .02f;
    }
}
