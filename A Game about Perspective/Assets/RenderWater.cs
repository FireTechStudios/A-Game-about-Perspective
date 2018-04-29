using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderWater : MonoBehaviour {

    public GameObject water;
    public GameObject cam2d;
    public GameObject cam32d;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(cam2d.activeSelf == true && cam32d.activeSelf == false)
            water.SetActive(false);
        else
            water.SetActive(true);
    }
}
