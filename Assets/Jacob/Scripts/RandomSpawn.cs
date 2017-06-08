using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    // Use this for initialization
    public Transform[] spawnpoints;

    public GameObject[] comets;

    public float timer = 10;
	void Start () {

        for(int i  =0; i< spawnpoints.Length; i++)
        {
            int rand = Random.Range(0, 4);

            Instantiate(comets[rand], spawnpoints[i].position, comets[rand].transform.rotation);
        }



		
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if(timer < 0)
        {

            for (int i = 0; i < spawnpoints.Length; i++)
            {
                int rand = Random.Range(0, 4);

                Instantiate(comets[rand], spawnpoints[i].position, comets[rand].transform.rotation);
            }

            timer = 10;
        }


		
	}
}
