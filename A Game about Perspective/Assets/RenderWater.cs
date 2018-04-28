using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderWater : MonoBehaviour {

    public GameObject water;
    public GameObject cam2d;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(cam2d.activeSelf == true)
            water.SetActive(false);
        else
            water.SetActive(true);
    }
}
