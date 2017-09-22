using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeScript : MonoBehaviour 
{
    public float scaleAmount;
    private float MaxScale;
    //reference to the object that needs to be modified with this script
    public GameObject objectToModify;
    //placeholder to store the original size of the object we are about to modify
    public float originalScaleAmount;
	// Use this for initialization
	void Start () 
	{
        //find the object that this script is attached to
        objectToModify = this.gameObject;
        //save the original size of the object
        originalScaleAmount = objectToModify.transform.localScale.x;
        //determine the max size of this objects increase to be 2.5x its original size
        MaxScale = originalScaleAmount * 2.5f;

        //Debug.Log(objectToModify.transform.localScale.x);
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
            transform.localScale = new Vector3(originalScaleAmount, originalScaleAmount, originalScaleAmount);
            scaleAmount = 0.0f;
        }
        else if (transform.localScale.x >= MaxScale)
        {
            transform.localScale = new Vector3(MaxScale, MaxScale, MaxScale);
            scaleAmount = 0.0f;
        }
    }
}
