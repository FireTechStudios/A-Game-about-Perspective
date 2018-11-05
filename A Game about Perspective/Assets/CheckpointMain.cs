using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMain : MonoBehaviour {

    public static Vector3 latestCheckpoint;
    public GameObject particles;
    public static bool hasGottenFirstCheckpoint = false;

    // Use this for initialization
    void Start () {
        particles.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            hasGottenFirstCheckpoint = true;
            particles.SetActive(true);
            latestCheckpoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);

        }
    }
}
