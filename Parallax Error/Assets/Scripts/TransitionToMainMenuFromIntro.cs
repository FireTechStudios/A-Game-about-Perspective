using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToMainMenuFromIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Menu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(1.55f);
        SceneManager.LoadScene("MainMenu");
    }
}
