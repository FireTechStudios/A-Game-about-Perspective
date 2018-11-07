using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTextRotate : MonoBehaviour {

    public GameObject actionText;
    public GameObject camera3d;
    public GameObject camera2d;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (camera3d.activeInHierarchy == true)
            actionText.transform.rotation = Quaternion.LookRotation(this.transform.position - camera3d.transform.position);
        else
            actionText.transform.rotation = Quaternion.LookRotation(this.transform.position - camera2d.transform.position);
    }
}
