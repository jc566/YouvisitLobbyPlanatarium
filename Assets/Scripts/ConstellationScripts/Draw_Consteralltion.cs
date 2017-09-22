using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Consteralltion : MonoBehaviour {

    // Use this for initialization



    public GameObject[] points;

    public List<Vector3> positions;

    public List<Vector3> positionsreached;

    public List<GameObject> pointsreached;

    public List<GameObject> movers;

    public float speed;

    public bool GazeOver;

    public float time;

    public GameObject nextpos;

    public Vector3 orginalpos;

    public GameObject mover;

    public int i;

    public int j;

    public int k;

    public Vector3 previouspos;

    public GameObject previouspoint;

    public bool first;

    public bool finished;

    public GameObject lastpoint;

    void Start () {

        finished = false;
        first = true;
        
        GazeOver = false;
        speed = 10;
        k = 1;
        i = 1;
        j = 0;
        orginalpos = transform.position;

        previouspos = points[0].transform.position;

        previouspoint = points[0];

        lastpoint = points[points.Length - 1];

        for(int w = 1; w < points.Length; w++)
        {
            positions.Add(points[w].transform.position);
            
        }
        movers.Add(mover);

    }

    // Update is called once per frame
    void Update() {
        
        if (GazeOver == true)
        {
            Draw();
        }
        else if(GazeOver == false)
        {
            
        }

    }


    public void GazeOn()
    {
        if(finished == false)
        {
            GazeOver = true;
        }
        else
        {
            GazeOver = false;
        }
    }

    public void GazeOff()
    {
        GazeOver = false;
    }

    //draws the constellation
    public void Draw()
    {
        //keeps going if the constellation is not done
        if (finished == false)
        {
            float step = speed * Time.deltaTime;

            
            //moves a gameobject with a trail render to the next position 
            if (first == true)
            {
                movers[j] = Instantiate(mover, previouspos, Quaternion.identity);
                first = false;
            }

            //moves the object with the trail render to the next point in the constellation, simulates drawing
            if (j < points.Length - 1)
            {
                movers[j].transform.position = Vector3.MoveTowards(movers[j].transform.position, points[k].transform.position, step);

                if(k == points.Length -1 && movers[j].transform.position == points[k].transform.position)
                {
                    finished = true;
                }
                
            }
            //checks to see if the constellation is done
            if (k < points.Length - 1 && movers[j].transform.position == points[k].transform.position)
            {
                //checks to see if the point in the constellation has already been drawn too
                //if it has not it will add the next position to be moved too
                if (!pointsreached.Contains(points[k + 1]))
                {
                    
                    previouspoint = points[k];

                    pointsreached.Add(previouspoint);
                }
                //if the position has been drawn to already it will teleport to that position and start drawing from it to prevent overlapping
                else
                {
                    previouspoint = points[k + 1];
                }

                k++;
                j++;
                movers.Add(mover);
                //creates the gameobject with the trailrender
                movers[j] = Instantiate(mover, previouspoint.transform.position, Quaternion.identity);
            }

        }
    }

    public void Draw2()
    {
       





    }
    //deletes the constellation
    public void Erase()
    {
        
        GazeOver = false;
        //checks to see if the constellation has finished drawing and if not it will delete the lines
        if (finished == false)
        {
            previouspos = points[0].transform.position;
            //detroys the gameobjects with the constellations to delete the trail renders
            for (int q = 0; q < movers.Count; q++)
            {
                

                DestroyObject(movers[q]);
            }


            //clears the lists to start fresh
            movers.Clear();

            positionsreached.Clear();

            pointsreached.Clear();

            positions.Clear();




            first = true;
            k = 1;
            i = 1;
            j = 0;
            orginalpos = transform.position;


            //readds the points needed to complete the constellation
            for (int w = 1; w < points.Length; w++)
            {
                positions.Add(points[w].transform.position);
                
            }
            //sets up the first one
            movers.Add(mover);
        }
    }
}
