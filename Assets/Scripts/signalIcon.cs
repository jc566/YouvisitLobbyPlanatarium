using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class signalIcon : MonoBehaviour {

	public Sprite[] signals;


	float color = 0;
	float timer = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >=1){
		
			StartCoroutine( ChangeSignal());
			timer = 0;
		}

	}


	private IEnumerator ChangeSignal()
	{

		color++;
		if (color > 2)
		{
			color = 0;
		}

		gameObject.GetComponent<Image>().sprite =signals[ Mathf.RoundToInt(color)];

		yield return new WaitForSecondsRealtime(1);
	}
}
