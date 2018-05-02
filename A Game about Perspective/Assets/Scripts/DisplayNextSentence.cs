using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNextSentence : MonoBehaviour {

    public GameObject diaglogueManager;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            diaglogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        }
	}
}
