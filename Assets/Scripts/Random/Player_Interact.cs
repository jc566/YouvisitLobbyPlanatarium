using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interact : MonoBehaviour
{

    // Use this for initialization


    Ray ray;
    RaycastHit hit;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //print(hit.gameobject.layer == LayerMask.NameToLayer("Tree"));

                // Debug.Log("Hit");

                if(RobotAI.state == 1)
                    {
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("mute"))
                        {
                            RobotAI.state = 3;
                        }
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("display"))
                        {
                            RobotAI.state = 4;
                        }
                    if (hit.transform.gameObject.layer == LayerMask.NameToLayer("skip"))
                        {
                            RobotAI.state = 5;
                        }
                        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("previous"))
                        {
                            RobotAI.state = 6;
                        }
                       
                    }

            }
        }
    }
}
