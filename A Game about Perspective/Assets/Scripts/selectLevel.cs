using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour {

    [SerializeField]
    public int level;

    public Button levelButton;

    // Use this for initialization
    void Start () {
        int getLevel = MenuController.selectedLevelInt;
        Button btn = levelButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        MenuController.selectedLevelInt = level;
    }
}
