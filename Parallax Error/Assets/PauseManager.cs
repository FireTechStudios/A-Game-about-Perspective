using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

    public GameObject Overlay;
    public GameObject PauseText;
    public Animator OverlayAnimator;
    public Animator PauseAnimator;
    public bool IsPaused;
    public GameObject player;
    public GameObject camera3d;
    public GameObject camera32d;
    public GameObject camera2d;
    public GameObject TransMan;
    public Button Reload;
    public Button Menu;
    public string ThisLevel;

    // Use this for initialization
    void Start () {
        Menu.interactable = false;
        Reload.interactable = false;
        OverlayAnimator = Overlay.GetComponent<Animator>();
        PauseAnimator = PauseText.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        TransMan = GameObject.Find("TransitionManager");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reload.interactable = !Reload.interactable;
            Menu.interactable = !Menu.interactable;
            IsPaused = !IsPaused;
            if (IsPaused == true)
            {
                OverlayAnimator.SetBool("IsPaused", true);
                PauseAnimator.SetBool("IsPaused", true);
                Pause();
            }
            else
            {
                OverlayAnimator.SetBool("IsPaused", false);
                PauseAnimator.SetBool("IsPaused", false);
                Unpause();
            }
        }
        if (IsPaused == false)
        {
            OverlayAnimator.SetBool("IsPaused", false);
            PauseAnimator.SetBool("IsPaused", false);
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
        IsPaused = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 50, 0);
        player.GetComponent<Rigidbody>().useGravity = false;
        if(camera3d.activeInHierarchy)
        {
            StartCoroutine(Animation32());

        }
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        StartCoroutine(ReloadAnimation(player));
    }

    public IEnumerator Animation32()
    {
        camera32d.SetActive(true);
        yield return new WaitForSeconds(1.35f);
        camera32d.SetActive(false);
        camera2d.SetActive(true);
    }

    public IEnumerator ReloadAnimation(GameObject player)
    {
        yield return new WaitForSeconds(1.5f);

        ThisLevel = SceneManager.GetActiveScene().name;

        //Important
        TransitionManager.TransitionIfNotMenuStatic(ThisLevel, TransMan);
    }

}
