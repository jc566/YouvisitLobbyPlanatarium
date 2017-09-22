using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation_LineRender : MonoBehaviour {
    public GameObject startingNode; //reference to the first node in the constellation

    public LineRenderer constellation; //reference to the line renderer for the constellation

    public GameObject[] constellationNodes; //reference to the list of gameobjects / nodes that make the complete constellation

	// Use this for initialization
	void Start () {
        constellation = this.gameObject.GetComponent<LineRenderer>();

        //Find all the objects with the Constellation name, determine the size among other things
        //constellationNodes = GameObject.FindGameObjectsWithTag("Orion");


        

        //constellation.positionCount = constellationNodes.Length;


        
	}
	
	// Update is called once per frame
	void Update () {
        connectDots();
    }

    public void connectDots()
    {
        constellation.positionCount = constellationNodes.Length;

        for (int i = 0; i < constellationNodes.Length; i++)
        {
            constellation.SetPosition(i, constellationNodes[i].transform.position);
        }
    }
}
