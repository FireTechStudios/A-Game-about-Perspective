using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {

    public string levelToTransition;
    public GameObject Level1;
    public GameObject RiseGround;
    public GameObject Timer;
    public bool reloadScene = false;

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        Level1 = GameObject.Find("Level1");
        Timer = GameObject.Find("Timer");
    }

    public static void TransitionToLevel(string level, GameObject NavMenu, GameObject Title, TransitionManager TransScript)
    {
        Cursor.visible = false;
        TransScript.MenuLeaveScreen(NavMenu, Title, level);
    }

    public void MenuLeaveScreen(GameObject NavMenu, GameObject Title, string RawLevel)
    {
        levelToTransition = RawLevel;
        var animTitle = Title.GetComponent<Animation>();
        animTitle.Play("LeaveScreenUp");
        var animNavMenu = NavMenu.GetComponent<Animation>();
        animNavMenu.Play("LeaveScreenDown");
        StartCoroutine(TransitionToTransitionLevel());
    }

    public static void TransitionIfNotMenuStatic(string level, GameObject TransMan)
    {
        TransMan.GetComponent<TransitionManager>().TransitionIfNotMenu(level);
    }

    public void TransitionIfNotMenu(string level)
    {
        levelToTransition = level;
        reloadScene = true;
        StartCoroutine(TransitionToTransitionLevel());
    }

    public IEnumerator TransitionToTransitionLevel()
    {
        yield return new WaitForSeconds(0.333f);
        SceneManager.LoadScene("Transition");
        yield return new WaitForSeconds(0.001f);
        if (reloadScene)
        {
            RiseGround = GameObject.Find("RiseGround");
            RiseGround.transform.position = new Vector3(76.3f, 50f, 0.75f);
            var animRiseGround = RiseGround.GetComponent<Animation>();
            animRiseGround.Play("GroundRise");
            reloadScene = false;
        }
        else
        {
            RiseGround = GameObject.Find("RiseGround");
            RiseGround.transform.position = new Vector3(76.3f, 55f, 0.75f);
        }
        StartCoroutine(MoveObjects(levelToTransition)); 
    }
    //In transition scene

    public IEnumerator MoveObjects(string level)
    {
        yield return new WaitForSeconds(0.334f);
        if (level == "Level1")
        {
            var animLevel1 = Level1.GetComponent<Animation>();
            animLevel1.Play("TutorialTransitionAnimation");
        }
        else
        {
            //ADD OTHER ANIMATION LEVEL TRANSITONS HERE
            Debug.Log("UnimplementedLevel");
        }
        if(level != "MainMenu")
        {
            var animTimer = Timer.GetComponent<Animation>();
            animTimer.Play("TimerFadeIn");
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

}
