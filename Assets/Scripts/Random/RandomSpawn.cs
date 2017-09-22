using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    // Use this for initialization
    public Transform[] spawnpoints; //reference to the spawnpoints of comets

    public GameObject[] comets;//array of comets to select from

    public float timer = 10;//spawn delay time
    void Start () {
        //for each spawn point attached to this script spawn comets
        for (int i  =0; i< spawnpoints.Length; i++)
        {
            //use a random number range to select from the list of comets to pick from
            int rand = Random.Range(0, comets.Length);

            //create random rotation
            comets[rand].transform.rotation = Random.rotation;

            //spawn the comets
            Instantiate(comets[rand], spawnpoints[i].position, comets[rand].transform.rotation);
        }



		
	}
	
	// Update is called once per frame
	void Update () {
        //subtract the timer for delay
        timer -= Time.deltaTime;
        //when the timer is up repeat the spawn cycle
        if (timer < 0)
        {
            for (int i = 0; i < spawnpoints.Length; i++)
            {
                int rand = Random.Range(0, comets.Length);
                //create random rotation
                comets[rand].transform.rotation = Random.rotation;

                Instantiate(comets[rand], spawnpoints[i].position, comets[rand].transform.rotation);
                Debug.Log(comets[rand].transform.position);
            }
            //reset the timer
            timer = Random.Range(10, 20);
        }


		
	}
}
