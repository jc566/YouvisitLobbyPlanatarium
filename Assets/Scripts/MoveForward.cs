using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
    public float movementSpeed; //determine the movement speed of the asteroid belts
    public GameObject endPoint; //reference to the ending location of belts
    public GameObject startPoint; //reference t othe start location of belts
    public float delayTime; //reference to the delaytime between each asteroid instance
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //move in direction according to World space
        //this.transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        //begin the coroutine
        StartCoroutine(delayedSpawn());
	}
    IEnumerator delayedSpawn()
    {
        //If the belt is not at the end location, move towards the end location
        if (transform.position != endPoint.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.transform.position, movementSpeed);
        }
        //if the belt reaches the end location, wait for X seconds and then relocate to the start location
        if (transform.position == endPoint.transform.position)
        {

            yield return new WaitForSeconds(30.0f);
            transform.position = startPoint.transform.position;
        }

        
    }

    public void getRandomNumber()
    {
        delayTime = Random.Range(10.0f, 20.0f);
    }
}
