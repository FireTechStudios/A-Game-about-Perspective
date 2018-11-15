using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTeleport : MonoBehaviour {

    public float teleportZ;
    public GameObject camera3d;
    public GameObject camera32d;
    private bool hasCollided = false;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!camera3d.activeInHierarchy && !camera32d.activeInHierarchy && hasCollided)
        {
            Force(teleportZ);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            hasCollided = true;
        }
    }

    public void Force(float z)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, z);
        hasCollided = false;
    }
}
