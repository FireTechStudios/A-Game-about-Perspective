using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
    public GameObject text;
    public GameObject trigger;

    public void Update()
    {
        if (text.GetComponent<FadeText>().isShown == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                trigger.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }
}