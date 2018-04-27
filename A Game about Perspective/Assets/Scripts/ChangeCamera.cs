using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject camera2d;
    public GameObject camera3d;
    public bool isin3d = false;
    public bool canbein3d = true;
    public bool grantFullcontrols = false;
    public float timeleftin3d = 10f;

    //<-- START CAMERA CONTROLS -->//

    void Start()
    {
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
        }

//<-- START PLAYER CONTROLS -->//

        if (isin3d == true)
        {
            grantFullcontrols = true;
        }

        //<-- END PLAYER CONTROLS -->//

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