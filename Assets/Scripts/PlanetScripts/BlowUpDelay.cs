using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowUpDelay: MonoBehaviour {
    [SerializeField]
    private float DelayLength;

    //Sample Explosion Effect
    [SerializeField]
    private GameObject blowEffect;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
        //StartCoroutine(blowUp(DelayLength));
    }

    
    IEnumerator blowUp(float time)
    {
        yield return new WaitForSeconds(time);
        //Comment out below if use alter Explosion effect.
        Destroy(gameObject);
        Instantiate(blowEffect, transform.position, Quaternion.identity);
    }

    public void startCoroutineBlowup()
    {
        StartCoroutine(blowUp(DelayLength));
    }
}
