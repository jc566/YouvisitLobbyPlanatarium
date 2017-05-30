using UnityEngine;

using System.Collections;

[RequireComponent(typeof(Collider))]
public class VRInteractable : MonoBehaviour
{
    //saves the original spin speed of an object with the spinScript attached
    public float savedSpinSpeed; 


    private Vector3 startingPosition;

    //public Material inactiveMaterial;
    //public Material gazedAtMaterial;

    void Start()
    {
        startingPosition = transform.localPosition;
        SetGazedAt(false);
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
        transform.localPosition = startingPosition;
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


    //Print a Debug.log message
    public void printMessage()
    {
        Debug.Log("This is Working");
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
