using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarScript : MonoBehaviour {
    AsyncOperation ao;
    public GameObject loadingScreen;
    public Slider progressBar;
    public Text loadingText;

    public bool isFakeLoadingBar = false;
    public float fakeIncrement = 0f;
    public float fakeTiming = 0f;

	// Use this for initialization
	void Start () {
        LoadLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void LoadLevel()
    {
        loadingScreen.SetActive(true);
        progressBar.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        loadingText.text = "loading...";

        if(!isFakeLoadingBar)
        {
            StartCoroutine(LoadLevelWithRealProgress());
        }
        else
        {

        }
    }

    IEnumerator LoadLevelWithRealProgress()
    {
        yield return new WaitForSeconds(1f);

        ao = SceneManager.LoadSceneAsync(0);
        ao.allowSceneActivation = false;

        while(!ao.isDone)
        {
            progressBar.value = ao.progress;

            if(ao.progress == 0.9f)
            {
                progressBar.value = 1.0f;
                loadingText.text = "press F to continue";
                if(Input.GetKeyDown(KeyCode.F))
                {
                    ao.allowSceneActivation = true;
                }
            }
            Debug.Log(ao.progress);
            yield return null;
        }
    }
}
