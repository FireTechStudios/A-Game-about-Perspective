using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject3D : MonoBehaviour {

    public GameObject ghostObjects;
    public GameObject camera3d;
    public GameObject camera23d;
    public GameObject camera32d;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (camera3d.activeInHierarchy)
        {
            ghostObjects.SetActive(false);
        }
        if (!camera3d.activeInHierarchy && !camera32d.activeInHierarchy)
            ghostObjects.SetActive(true);
	}
}
