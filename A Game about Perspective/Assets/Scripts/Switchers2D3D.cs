using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchers2D3D : MonoBehaviour {

    public GameObject enabledIn2D;
    public GameObject enabledIn3D;
    public GameObject camera3d;

	// Use this for initialization
	void Start () {
        enabledIn2D.SetActive(true);
        enabledIn3D.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if (camera3d.activeInHierarchy)
        {
            enabledIn3D.SetActive(true);
            enabledIn2D.SetActive(false);
        }
        else
        {
            enabledIn2D.SetActive(true);
            enabledIn3D.SetActive(false);
        }

    }
}
