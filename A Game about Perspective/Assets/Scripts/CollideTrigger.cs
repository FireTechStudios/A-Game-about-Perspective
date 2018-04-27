using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{

    public GameObject player;
    public GameObject trigger;
    public bool hasAlreadyTriggered;

    private void Awake()
    {
        hasAlreadyTriggered = false;
    }

    void OnTriggerEnter(Collider player)
    {
        if (hasAlreadyTriggered == false)
            trigger.GetComponent<DialogueTrigger>().TriggerDialogue();
            hasAlreadyTriggered = true;
    }
}