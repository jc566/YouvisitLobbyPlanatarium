using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Indiv : MonoBehaviour {

    // Use this for initialization


    public GameObject[] comets;


    public float timer ;

    void Start () {


        timer = Random.Range(10, 15);
            int rand = Random.Range(0, comets.Length);

            Instantiate(comets[rand], transform.position, comets[rand].transform.rotation);
        
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer < 0)
        {

            
                int rand = Random.Range(0, comets.Length);

                Instantiate(comets[rand], transform.position, comets[rand].transform.rotation);
            

            timer = Random.Range(10, 20);
        }
    }
}
