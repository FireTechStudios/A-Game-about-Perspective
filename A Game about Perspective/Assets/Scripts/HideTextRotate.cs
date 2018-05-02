using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTextRotate : MonoBehaviour {

    public GameObject parent;
    public GameObject camera3d;
    public GameObject camera2d;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (camera3d.activeInHierarchy == true)
            parent.transform.LookAt(camera3d.transform);
        else
            parent.transform.LookAt(camera2d.transform);
    }
}
