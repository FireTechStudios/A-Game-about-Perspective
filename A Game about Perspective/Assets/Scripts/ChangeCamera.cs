using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera2d;
    public GameObject camera25d;
    public GameObject camera3d;
    public bool isin3d = false;
    public bool canbein3d = true;
    public bool grantFullcontrols = false;
    public float timeleftin3d = 10f;

    public float transitionTimeout = 1.35f;
    // Private stuff to make the activation timer work
    private float transitionTimeRemaining;
    private bool transitionActive = false;


    //<-- START CAMERA CONTROLS -->//

    void Start()
    {
        transitionTimeRemaining = transitionTimeout;
        transitionActive = false;

        camera2d.SetActive(true);
        camera3d.SetActive(false);
    }


        void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canbein3d == true && timeleftin3d <= 10)
            {
                camera3d.SetActive(true);
                camera2d.SetActive(false);
                canbein3d = false;
                isin3d = true;
            }
            else if (canbein3d == false && timeleftin3d <= 10)
            {
                camera3d.SetActive(false);
                camera2d.SetActive(true);
                canbein3d = true;
                isin3d = false;
            }

            if (!transitionActive && transitionTimeRemaining > 0 && isin3d == true)
            {
                // Reduce the remaining time by time passed since last update (frame)
                transitionTimeRemaining -= Time.deltaTime;
                camera25d.SetActive(true);
            }
            else
            {
                // The gun is now disabled and the timer is reset
                transitionTimeRemaining = transitionTimeout;
                transitionActive = false;
                camera25d.SetActive(false);
            }

            //<-- START PLAYER CONTROLS -->//

            if (isin3d == true)
            {
                grantFullcontrols = true;
            }

            //<-- END PLAYER CONTROLS -->//

        }
    }

    void FixedUpdate()
    {
        if (isin3d == true)
        {
            timeleftin3d -= Time.deltaTime;
        }


        if (timeleftin3d >= 10)
        {
            canbein3d = true;
            timeleftin3d = 10;
        }

        if (timeleftin3d <= 0)
        {
            camera3d.SetActive(false);
            camera2d.SetActive(true);
            canbein3d = false;
            isin3d = false;
            grantFullcontrols = false;
            timeleftin3d = 0;
        }

        if (timeleftin3d < 10)
        {
            if (isin3d == false)
            {
                timeleftin3d += Time.deltaTime;
            }
        }
    }

    //<-- END CAMERA CONTROLS -->//
}