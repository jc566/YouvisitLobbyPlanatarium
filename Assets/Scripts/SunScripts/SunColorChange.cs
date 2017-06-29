using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunColorChange : MonoBehaviour
{
    //List of supernova colors
    public Color[] supernovaPhases;
    public GameObject sunSurface;
    public GameObject corona;
    private ParticleSystem ps;

    // Use this for initialization
    void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        supernovaPhases = new Color[7];
        supernovaPhases[0] = Color.red;                     //red  
        supernovaPhases[1] = new Color32(255, 142, 0, 255);    //orange
        supernovaPhases[2] = Color.yellow;                  //yellow
        supernovaPhases[3] = new Color32(139, 146, 20, 255);   //yellow-white
        supernovaPhases[4] = new Color32(205, 205, 205, 255);  //white
        supernovaPhases[5] = new Color32(11, 13, 62, 255);     //blue-white
        supernovaPhases[6] = Color.blue;                    //blue

        //Start the Coroutine handling color change
        StartCoroutine("ChangeColor");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    
    IEnumerator ChangeColor()
    {
        //Get the "Color Over Lifetime" attribute from particle system attached to Sun object
        ParticleSystem.ColorOverLifetimeModule module = ps.colorOverLifetime;
        //Get the "Color Over Lifetime" attribute from particle system attached to Corona object
        ParticleSystem.ColorOverLifetimeModule coronaModule = corona.GetComponent<ParticleSystem>().colorOverLifetime;

        Gradient gradient = new Gradient();
        Color initialColor = module.color.gradient.colorKeys[0].color;
        Color initSurfaceColor = sunSurface.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        //Variables used to hold the color of the sun's radiance and surface color
        Color color;
        Color surfaceColor;
        //Loop through the 7 supernova colors  
        for (int i = 0; i < 7; i++)
        {
            //Gradually transition to the next supernova color
            for (int j = 0; j < 20; j++)
            {
                //Lerp towards the next supernova color  
                color = Color.Lerp(initialColor, supernovaPhases[i], j / 20.0f);
                surfaceColor = Color.Lerp(initSurfaceColor, supernovaPhases[i], j / 20.0f);
                //Set the color of the sun's surface
                sunSurface.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", surfaceColor);
                //Colors values of the gradient used for the sun's corona and radiance
                GradientColorKey[] colorKey =
                { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(color, 0.125f),
                  new GradientColorKey(color, 0.90f), new GradientColorKey(Color.white, 1.0f) };
                //Alpha values of the gradient for the sun's corona and radiance 
                GradientAlphaKey[] alphaKey = { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.125f),
                new GradientAlphaKey(1.0f, 0.90f), new GradientAlphaKey(0.0f, 1.0f) };
                //Set values for gradient
                gradient.SetKeys(colorKey, alphaKey);
                //Set gradient for sun's radiance and corona
                module.color = gradient;
                coronaModule.color = gradient;

                yield return new WaitForSeconds(0.1f);
            }
            //Update initial colors 
            initialColor = supernovaPhases[i];
            initSurfaceColor = sunSurface.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        }
    }
}
