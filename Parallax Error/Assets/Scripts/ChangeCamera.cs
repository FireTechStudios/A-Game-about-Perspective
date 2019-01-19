using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera2d;
    public GameObject camera23d;
    public GameObject camera32d;
    public GameObject camera3d;
    public bool isin3d = false;
    public bool canbein3d = true;
    public static bool isTransitioningTo3d = false;
    public static bool isTransitioningTo2d = false;
    public static bool isIn3D;
    public bool grantFullcontrols = false;
    public float timeleftin3d = 10f;
    public float timeAllowedIn3D;
    public static bool isTransitioning;

    //<-- START CAMERA CONTROLS -->//

    void Start()
    {
        camera2d.SetActive(true);
        camera3d.SetActive(false);
        camera23d.SetActive(false);
        camera32d.SetActive(false);
    }


        void Update()
        {
        isIn3D = isin3d;
        if (Input.GetKeyDown(KeyCode.E) && !isTransitioningTo3d && !isTransitioningTo2d && !PauseManager.Transitioning && !DialogueManager.isInDialogue)
        {
            if (canbein3d == true && timeleftin3d <= timeAllowedIn3D && isin3d == false)
            {
                isTransitioningTo3d = true;
                StartCoroutine(TransitionBuffer23());
                StartCoroutine(Animation23());
            }
            else if (canbein3d == false && timeleftin3d <= timeAllowedIn3D && isin3d == true)
            {
                isTransitioningTo2d = true;
                StartCoroutine(TransitionBuffer32());
                StartCoroutine(Animation32());
            }
            else if (canbein3d == true && isin3d == true)
            {
                isTransitioningTo2d = true;
                StartCoroutine(TransitionBuffer32());
                StartCoroutine(Animation32());
            }

        }
        if (isin3d == true)
        {
            grantFullcontrols = true;
        }
    }

    public IEnumerator TransitionBuffer23()
    {
        isTransitioningTo3d = true;
        camera3d.SetActive(true);
        camera2d.SetActive(false);
        yield return new WaitForSeconds(1.35f);
        canbein3d = false;
        isin3d = true;
        isTransitioningTo3d = false;
    }

    public IEnumerator TransitionBuffer32()
    {


        grantFullcontrols = false;
        isTransitioningTo2d = true;
        camera3d.SetActive(false);
        camera2d.SetActive(false);
        isin3d = false;
        yield return new WaitForSeconds(1.35f);
        camera3d.SetActive(false);
        camera2d.SetActive(true);
        canbein3d = true;
        isTransitioningTo2d = false;
    }

    public IEnumerator Animation32()
    {
        camera32d.SetActive(true);
        yield return new WaitForSeconds(1.35f);
        camera32d.SetActive(false);
    }

    public IEnumerator Animation23()
    {
        camera23d.SetActive(true);
        yield return new WaitForSeconds(1.35f);
        camera23d.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isin3d == true && !DialogueManager.isInDialogue && !isTransitioning)
        {
            timeleftin3d -= Time.deltaTime;
        }


        if (timeleftin3d >= timeAllowedIn3D)
        {
            canbein3d = true;
            timeleftin3d = timeAllowedIn3D;
        }

        if (timeleftin3d > 0 )
        {
            canbein3d = true;
        }

        if (timeleftin3d <= 0)
        {
            isin3d = false;
            grantFullcontrols = false;
            timeleftin3d = 0.001f;
            StartCoroutine(TransitionBuffer32());
            StartCoroutine(Animation32());
        }

        if (timeleftin3d < timeAllowedIn3D)
        {
            if (isin3d == false && !DialogueManager.isInDialogue && !isTransitioning)
            {
                timeleftin3d += Time.deltaTime * 5f;
            }
        }

        if (isTransitioningTo2d || isTransitioningTo3d)
            isTransitioning = true;
        else
            isTransitioning = false;

    }

    //<-- END CAMERA CONTROLS -->//
}