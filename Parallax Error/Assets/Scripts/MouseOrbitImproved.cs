using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class MouseOrbitImproved : MonoBehaviour
{
    public Transform target;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;
    public Quaternion startPos;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public GameObject cam3d;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        startPos = Quaternion.Euler(15, 90, 0);

        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
        // Make the rigid body not change rotation
    }

    void LateUpdate()
    {
        if (cam3d.activeInHierarchy)
        {
            Quaternion rotation = Quaternion.Euler(y, x, 0);

            if (!PauseManager.IsPaused)
            {
                if(!DialogueManager.isInDialogue)
                {
                    if(!ChangeCamera.isTransitioning)
                    {
                        x += Input.GetAxis("Mouse X") * xSpeed * 0.02f * Time.timeScale;

                    }

                    transform.rotation = rotation;
                }
            }

        }
        else
        {
            transform.rotation = startPos;
            x = startPos.x;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}