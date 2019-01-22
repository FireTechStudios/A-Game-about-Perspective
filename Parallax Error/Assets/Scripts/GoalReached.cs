using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GoalReached : MonoBehaviour {

    public GameObject goalOverlay;
    public GameObject pauseOverlay;
    public TextMeshProUGUI title;
    public string levelName;
    public bool win;

    // Use this for initialization
    void Start () {
        title.text = levelName + " \nComplete";
    }
	
	// Update is called once per frame
	void Update () {
        if(win)
        {
            SlowMotionStop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Win();
        }
    }

    public void Win()
    {
        win = true;
        goalOverlay.SetActive(true);
        Cursor.visible = true;
        pauseOverlay.SetActive(false);
    }

    public void SlowMotionStop()
    {
        if(Time.timeScale > 0.0f)
        {
            if(Time.timeScale < 0.05f)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale -= 0.5f * Time.unscaledDeltaTime;
            }
        }
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
