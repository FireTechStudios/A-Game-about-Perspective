using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EscToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
         if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("Level1"); //or whatever number your scene is
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu"); //or whatever number your scene is
    }
}
