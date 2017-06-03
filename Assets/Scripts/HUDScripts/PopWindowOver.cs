using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopWindowOver : MonoBehaviour {
    [SerializeField]
    private string title = "My Window";
    [SerializeField]
    private static float windowWidth = 200f;
    [SerializeField]
    private static float windowHeight = 250f;
    [SerializeField]
    private string text = "This is the text Area";

    public GUIStyle textStyle;

    private Rect windowRect = new Rect(Screen.width/2, Screen.height/2, windowWidth, windowHeight);
    // Use this for initialization
    private bool gazeOver = false;

    public void GazeEnter()
    {
        gazeOver = true;
    }

    public void GazeExit()
    {
        gazeOver = false;
    }

    void Update()
    {
        //Define the window's position
        windowRect.x = (Screen.width - windowWidth) / 2;
        windowRect.y = (Screen.height - windowHeight) / 2 - Screen.height * 0.3f;
    }

    void OnGUI()
    {
        if (gazeOver)  //Draw window if this is true;
            windowRect = GUI.Window(0, windowRect, DoMyWindow, title);
    }
    void DoMyWindow(int windowID)
    {
        //The component of the window.
        GUI.TextField(new Rect(20, 30, (windowWidth - (0.2f * windowWidth)), (windowHeight - (0.5f * windowHeight))), text, textStyle);
    }
}
