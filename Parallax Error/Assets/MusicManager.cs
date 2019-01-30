using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MusicManager : MonoBehaviour {

    public Settings gameSettings;
    public AudioListener listener;
    public AudioSource retro;
    public AudioSource orchestral;
    public float changeValue = 0.75f;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        retro.volume = 100;
        orchestral.volume = 0;

        retro.Play();
        orchestral.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(ChangeCamera.isTransitioningTo2d)
        {
            retro.volume += changeValue * Time.deltaTime;
            orchestral.volume -= changeValue * Time.deltaTime;
        }
        if(ChangeCamera.isTransitioningTo3d)
        {
            retro.volume -= changeValue * Time.deltaTime;
            orchestral.volume += changeValue * Time.deltaTime;
        }
	}

}
