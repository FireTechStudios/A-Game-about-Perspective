using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

    public bool currentlyScrolling = false;

    public string PreviousSentence;

    public string sentence;

    public Animator animator;

	public Queue<string> sentences;

    public bool canEnd = false;

    // Use this for initialization
    void Start () {
		sentences = new Queue<string>();
	}



	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
        canEnd = false;
        DisplayNextSentence();
	}

    //When Enter is Pressed
    public void DisplayNextSentence()
	{
        if(sentences.Count != 0)
        {
            sentence = sentences.Dequeue();
        }
        if (currentlyScrolling)
        {
            Skip(sentence);
        }
        else //Enter is pressed at end of sentence
        {
            if(canEnd) //Loop once more
            {
                EndDialogue();
                return;
            }
            if (sentences.Count == 0) //Loop once more
            {
                canEnd = true;
            }

            StopAllCoroutines();

            StartCoroutine(TypeSentence(sentence));
        }
	}


    IEnumerator TypeSentence (string sentence)
	{
        PreviousSentence = sentence;
        dialogueText.text = "";
        currentlyScrolling = true;
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        currentlyScrolling = false;
    }


    void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

    public void Skip(string sentence)
    {
        if(Input.GetKeyDown(KeyCode.Return) && currentlyScrolling)
        {
            StopAllCoroutines();
            currentlyScrolling = false;
            dialogueText.text = PreviousSentence;

        }
    }

}
