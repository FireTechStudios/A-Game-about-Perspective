using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour {

    [SerializeField]
    public int level;
    public Color creamGreen = new Color(2.45F, 0.81F, 2.55F, 1F);
    public Button levelButton;

    // Use this for initialization
    void Start () {
        int getLevel = MenuController.selectedLevelInt;
        Button btn = levelButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        if (MenuController.selectedLevelInt == level)
        {
            ColorBlock cb = levelButton.colors;
            cb.normalColor = creamGreen;
            levelButton.colors = cb;
        }
        else
        {
            ColorBlock cb = levelButton.colors;
            cb.normalColor = Color.white;
            levelButton.colors = cb;
        }
    }

    void TaskOnClick()
    {
        MenuController.selectedLevelInt = level;
    }
}
