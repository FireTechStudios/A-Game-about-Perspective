using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeText : MonoBehaviour {
    public GameObject player;
    public bool isShown;
    public TextMeshPro text;
    public float alpha = 0f;
    public Color tempColor;


    public void Start()
    {
        tempColor = new Color(255, 255, 255, alpha);
    }

    public void StartFade()
    {
        isShown = false;
    }

    public void StopFade()
    {
        isShown = true;
    }

    private void Update()
    {
        text.faceColor = tempColor;

        if (alpha >= 1)
            alpha = 1;

        if (alpha <= 0)
            alpha = 0;

        if (isShown == true)
        {
            alpha += Time.deltaTime * 0.5f;
        }
        else
        {
            alpha -= Time.deltaTime * 1.5f;
        }
    }

    private void LateUpdate()
    {
        tempColor = new Color(255, 255, 255, alpha);
    }
}
