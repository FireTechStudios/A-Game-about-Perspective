using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {

    public string levelToTransition;
    public GameObject Level1;
    public GameObject RiseGround;
    public bool reloadScene = false;

    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update() {
        Level1 = GameObject.Find("Level1");
        RiseGround = GameObject.Find("RiseGround");
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
        StartCoroutine(MoveObjects(levelToTransition)); 
    }


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
            Debug.Log("NotLevel1");
        }

        if(reloadScene)
        {
            RiseGround.transform.position = new Vector3(-9.5f, -9f, -115.25f);
            var animRiseGround = RiseGround.GetComponent<Animation>();
            animRiseGround.Play("GroundRise");
            reloadScene = false;
        }
        else
        {
            RiseGround.transform.position = new Vector3(-9.5f, -4.5f, -115.25f);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

}
