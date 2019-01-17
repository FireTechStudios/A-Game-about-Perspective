using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public GameObject Overlay;
    public GameObject PauseText;
    public GameObject player;
    public GameObject camera3d;
    public GameObject camera32d;
    public GameObject camera2d;
    public GameObject TransMan;
    public GameObject Timer3D;

    public Animator OverlayAnimator;
    public Animator PauseAnimator;
    public Animator Timer3DAnimator;

    public static bool IsPaused;
    public static bool Transitioning;

    public Button Reload;
    public Button Menu;

    public string ThisLevel;

    // Use this for initialization
    void Start () {

        Menu.interactable = false;
        Reload.interactable = false;
        Timer3DAnimator = Timer3D.GetComponent<Animator>();
        OverlayAnimator = Overlay.GetComponent<Animator>();
        PauseAnimator = PauseText.GetComponent<Animator>();
        Transitioning = false;
        Timer3DAnimator.SetBool("ExitToMenu", false);
    }
	
	// Update is called once per frame
	void Update () {
        TransMan = GameObject.Find("TransitionManager");
        if (Input.GetKeyDown(KeyCode.Escape) && !Transitioning)
        {
            Reload.interactable = !Reload.interactable;
            Menu.interactable = !Menu.interactable;
            IsPaused = !IsPaused;
            if (IsPaused == true)
            {
                OverlayAnimator.SetBool("IsPaused", true);
                Pause();
            }
            else
            {
                OverlayAnimator.SetBool("IsPaused", false);
                Unpause();
            }
        }
        if (IsPaused == false)
        {
            OverlayAnimator.SetBool("IsPaused", false);
            Unpause();
        }
	}

    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        Cursor.visible = false;

    }

    public void ReloadScene()
    {
        player.GetComponent<BoxCollider>().isTrigger = true;
        Timer3DAnimator.SetBool("ExitToMenu", true);
        Transitioning = true;
        IsPaused = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 50, 0);
        player.GetComponent<Rigidbody>().useGravity = false;
        if(camera3d.activeInHierarchy)
        {
            StartCoroutine(Animation32());

        }
        StartCoroutine(ReloadAnimation());
    }

    public void MainMenu()
    {
        Timer3DAnimator.SetBool("ExitToMenu", true);

        Transitioning = true;
        IsPaused = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 50, 0);
        player.GetComponent<Rigidbody>().useGravity = false;

        if (camera3d.activeInHierarchy)
        {
            StartCoroutine(Animation32());

        }

        StartCoroutine(MenuAnimation());
    }

    public IEnumerator Animation32()
    {
        camera32d.SetActive(true);
        yield return new WaitForSeconds(1.35f);
        camera32d.SetActive(false);
        camera2d.SetActive(true);
    }

    public IEnumerator ReloadAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        ThisLevel = SceneManager.GetActiveScene().name;

        //Important
        
        TransitionManager.TransitionIfNotMenuStatic(ThisLevel, TransMan);
        
    }

    public IEnumerator MenuAnimation()
    {
        yield return new WaitForSeconds(1.5f);

        ThisLevel = "MainMenu";

        //Important
        
        TransitionManager.TransitionIfNotMenuStatic(ThisLevel, TransMan);
    }

}
