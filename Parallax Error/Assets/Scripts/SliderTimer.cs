using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTimer : MonoBehaviour {

    public Slider timer;
    public float timeLeftLocal;
    public GameObject Player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeftLocal = Player.GetComponent<ChangeCamera>().timeleftin3d;
        timer.value = timeLeftLocal;
    }
}
