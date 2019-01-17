using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GoalReached : MonoBehaviour {

    public TextMeshProUGUI Title;
    public TextMeshProUGUI Deaths;
    public TextMeshProUGUI Time;
    public string level;

    // Use this for initialization
    void Start () {
        level = SceneManager.GetActiveScene().name;
        Title.text = level+" Complete";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
