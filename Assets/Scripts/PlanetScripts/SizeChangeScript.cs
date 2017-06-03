using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeScript : MonoBehaviour 
{
    public float scaleAmount;
    private const float MaxScale = 2.0f;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        ChangeSize();
	}
    
    public void ChangeSize()
    {
        transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);

        //Clamps the scale of the object
        if (transform.localScale.x <= 1.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            scaleAmount = 0.0f;
        }
        else if (transform.localScale.x >= MaxScale)
        {
            transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
            scaleAmount = 0.0f;
        }
    }
}
