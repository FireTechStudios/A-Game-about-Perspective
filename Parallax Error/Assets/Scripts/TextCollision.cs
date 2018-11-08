using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollision : MonoBehaviour {

    public GameObject text;
    public bool isColliding = false;

    void OnTriggerEnter(Collider collidedObj)
    {
        if (collidedObj.tag == "Player")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collidedObj)
    {
        if (collidedObj.tag == "Player")
        {
            isColliding = false;

        }
    }

    void OnDisable()
    {
        isColliding = false;
    }

    void Update()
    {
        if(isColliding)
        {
            text.GetComponent<FadeText>().StopFade();
        }
        else
        {
            text.GetComponent<FadeText>().StartFade();
        }
    }

}
