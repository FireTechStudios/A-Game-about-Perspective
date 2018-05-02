using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollision : MonoBehaviour {

    public GameObject text;

    void OnTriggerEnter(Collider colidedObj)
    {
        if (colidedObj.tag == "Player")
        {
            text.GetComponent<FadeText>().StopFade();
        }
    }

    void OnTriggerExit(Collider colidedObj)
    {
        if (colidedObj.tag == "Player")
        {
            text.GetComponent<FadeText>().StartFade();
        }
    }
}
