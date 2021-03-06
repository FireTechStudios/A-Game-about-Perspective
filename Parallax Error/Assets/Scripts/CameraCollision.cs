﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {

    public Quaternion startPos;
    public float minDistance = 1.0f;
	public float maxDistance = 4.0f;
	public float smooth = 10.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;
	public float distance;


    private void Start()
    {
        startPos = Quaternion.Euler(15, 90, 0);
    }
    // Use this for initialization
    void Awake () {
		dollyDir = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 desiredCameraPos = transform.parent.TransformPoint (dollyDir * maxDistance);
		RaycastHit hit;


		if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit)) {
            if (hit.collider.transform.parent.tag != "NoCameraCollision")
            {
                distance = Mathf.Clamp((hit.distance * 0.87f), minDistance, maxDistance);
            }
            else
            {
                distance = maxDistance;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }
        else
        {
            distance = maxDistance;
            transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
        }

    }

    private void OnEnable()
    {
        this.gameObject.transform.eulerAngles.Set(startPos.x, startPos.y, startPos.z);
    }
}
