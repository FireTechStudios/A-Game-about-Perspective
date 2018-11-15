using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathCollider : MonoBehaviour {

    public Vector3 latestCheckpoint;
    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        latestCheckpoint = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        if(CheckpointMain.hasGottenFirstCheckpoint == true)
            latestCheckpoint = new Vector3(CheckpointMain.latestCheckpoint.x, CheckpointMain.latestCheckpoint.y, CheckpointMain.latestCheckpoint.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ocean")
        {
            this.gameObject.transform.position = latestCheckpoint;
            rb.velocity = Vector3.zero;
        }
    }
}
