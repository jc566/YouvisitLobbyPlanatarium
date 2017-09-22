/************************************************************
 * This script was created by :                             *
 * Joseph Choi / Jacob Maher / Shannon Hargrove / Lin Chen  *
 ***********************************************************/
using UnityEngine;

using System.Collections;

[RequireComponent(typeof(Collider))]
public class VRInteractable : MonoBehaviour
{
    //saves the original spin speed of an object with the spinScript attached
    public float savedSpinSpeed;

    //placeholder to store the original size of the object we are about to modify
    public float originalScaleAmount;


    //Material used when the object is not being gazed at
    public Material inactiveMaterial;

    //Material used when the object is being gazed at
    public Material activeMaterial;

    private Vector3 startingPosition;

    //The amount to scale an object with SizeChangeScript.cs attached
    private float ScaleAmount;

    //this bool will allow toggling of clicks and its functionailities to occur as needed
    public bool isClicked;

    void Start()
    {
        //startingPosition = transform.localPosition;
        SetGazedAt(false);

        //save the original size of the object
        originalScaleAmount = this.gameObject.transform.localScale.x;
        //state that the scale amount will be 2.5x the original size to pass along to sizechangescript
        ScaleAmount = originalScaleAmount * 2.5f;
        //Define isClickeds boolean value to false by default
        isClicked = false;
    }

    void Update()
    {
        retainSize();    
    }

    public void SetGazedAt(bool gazedAt)
    {
        /*if (inactiveMaterial != null && gazedAtMaterial != null)
        {
            GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;*/

        //Debug.Log(gazedAt);
        printMessage();

    }

    public void Reset()
    {
        //transform.localPosition = startingPosition;
    }
    /************************************
     * spinScript.cs Altering Functions *
     ***********************************/
    //Increase the Spin Speed of an Object that has the spinScript attached.
    public void IncreaseSpinSpeed(bool gazedAt)
    {
        //Save the original spinning speed
        savedSpinSpeed = this.gameObject.GetComponent<SpinScript>().spinSpeed;
        //Change the spin speed. Can change 100.0f to a variable in case we want to randomize this number.
        this.gameObject.GetComponent<SpinScript>().spinSpeed = 100.0f;
    }
    //Revert the Spin Speed of an Object that has the spinScript attached to its original speed.
    public void RevertSpinSpeed(bool gazedAt)
    {
        //Restore the originally saved Speed
        this.gameObject.GetComponent<SpinScript>().spinSpeed = savedSpinSpeed;
    }
    //Changes the Spin Direction of an Object that has the spinScript attached.
    public void ChangeSpinDirection(bool gazedAt)
    {
        this.gameObject.GetComponent<SpinScript>().spinSpeed *= -1.0f;
    }
    /************************************
     * SizeChangeScript.cs Altering Functions *
     ***********************************/
    //Changes the color and material, and increases the scale of an object with SizeChangeScript.cs attached.
    public void IncreaseSize()
    {
        //GetComponent<MeshRenderer>().material = activeMaterial;
        //GetComponent<MeshRenderer>().material.color = Color.green;
        if(isClicked == false)
        StartCoroutine("triggerIncreaseSize");
    }
    public void StopIncreaseSize()
    {
        StopCoroutine("triggerIncreaseSize");
        Debug.Log("stop");
    }
    //Changes the material, and decreases the scale of an object with SizeChangeScript.cs attached.
    public void DecreaseSize()
    {
        //GetComponent<MeshRenderer>().material = inactiveMaterial;
        this.gameObject.GetComponent<SizeChangeScript>().scaleAmount = -ScaleAmount;
    }
    public IEnumerator triggerIncreaseSize()
    {
        this.gameObject.GetComponent<SizeChangeScript>().scaleAmount = ScaleAmount;
        yield return new WaitForSeconds(0.1f);
    }
   
   
    public void retainSize()
    {
        if(isClicked)
        {

            //this.gameObject.GetComponent<SizeChangeScript>().scaleAmount = -ScaleAmount;
            DecreaseSize();
            
            //this.gameObject.GetComponent<SizeChangeScript>().enabled = false;
        }
        else
        {
            //this.gameObject.GetComponent<SizeChangeScript>().enabled = true;
        }
    }
    public void toggleClicks()
    {
        //make it toggle its value by making it NOT its current state
        isClicked = !isClicked;
    }

    /**************************************************
     * Planet Explosion triggered from BlowUpDelay.cs *
     *************************************************/
    //Planet Blows up
    public void triggerPlanetExplosion()
    {
        this.gameObject.GetComponent<BlowUpDelay>().startCoroutineBlowup();
    }

    //Print a Debug.log message
    public void printMessage()
    {
        //Debug.Log("This is Working");
    }

    public void Recenter()
    {
#if !UNITY_EDITOR
    GvrCardboardHelpers.Recenter();
#else
        GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
        if (emulator == null)
        {
            return;
        }
        emulator.Recenter();
#endif  // !UNITY_EDITOR
    }

   
}
