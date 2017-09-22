using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopWindowOver : MonoBehaviour {

    //public GameObject Parent;
    public Canvas newCanva;

    //public GameObject Canva_location;
    public string text_content;

    //public GameObject Text_area;
    public Text textarea;


    private bool gazeOver = false;

    void Start()
    {
        //newCanva.gameObject.SetActive(false);

        //locate the canvas on player
        newCanva = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Canvas>();
        //locate the text box on player for the canvas
        textarea = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Text>();
    }

    //Show canva when reticle is hover at object;
    public void GazeEnter()
    {
//        textarea.text = text_content;
     //   newCanva.gameObject.SetActive(true);
    }

    //Hide canva when reticle is no longer hover at object;
    public void GazeExit()
    {
        newCanva.gameObject.SetActive(false);
    }


    //Toggle on and off the canva.  
    public void TaggleOnAndOf()
    {
        //Deactivate the Canva if Canva is already actived, otherwise active the canva.  
        if (newCanva.gameObject.activeInHierarchy)
        {
            newCanva.gameObject.SetActive(false);
        }
        else
        {
            textarea.text = text_content;
            newCanva.gameObject.SetActive(true);
        }
    }
}