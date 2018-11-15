using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public static MenuController instance;

    //Active option and bool to check if main menu is active
    private int option = 0;
    private bool mainMenu = true;

    //Scenes animation
    //private bool isAnimating = false;
    //private int activeScene = 1;
    [SerializeField, Tooltip("Animation speed in seconds")]
    public float animSpeed;

    //Option quantity
    [SerializeField, Tooltip ("Introduce all the options in your menu")]
    public string[] options;

    //Backgrounds
    [SerializeField]
    public Text menuText;
    [SerializeField]
    public GameObject[] activeBackground;

    //Menu bar gameobject
    [SerializeField]
    public GameObject menuBar;

    //Sounds
    [Header("Sounds")]
    [Space(10)]
    public AudioClip Select;
    public AudioClip SceneSelect;
    private AudioSource Audio;

    //Events
    [SerializeField]
    public UnityEvent[] Events;

    //Exit Menu
    [SerializeField]
    public GameObject exitMenu;

    //Level Select
    [SerializeField]
    public GameObject levelSelect;
    [SerializeField]
    public static int selectedLevelInt;
    public string selectedLevel;

    //Options menu
    [SerializeField]
    public GameObject OptionsMenu;

    //Title
    public GameObject title;
    public TransitionManager TransScript;

    public bool isMenuOpen = false;

    void Start()
    {
        Cursor.visible = true;
        Audio = gameObject.GetComponent<AudioSource>();
        instance = this;

    }

	void Update () {

        if (mainMenu) { 
        //Changes the text corresponding option
        menuText.text = options[option];
        }
    }

    //Press enter or click on option 
    public void pressEnter()
    {
        if(!isMenuOpen)
            Events[option].Invoke();
    }

    //Function to go foward in the menu
    public void moveRight()
    {
        if(option < options.Length-1 && !isMenuOpen)
        {
            option = option + 1;
        }
    }

    //Function to go back in the menu
    public void moveLeft()
    {
        if (option > 0 && !isMenuOpen)
        {
            option = option - 1;

        }
    }
    
    //New Game event
    public void newGame()
    {
        //Loads the first scene, change the number to your desired scene
        var selectedLevel = "Level1";
        TransitionManager.TransitionToLevel(selectedLevel, menuBar, title, TransScript);
    }

    //Opens the exit menu
    public void exitMenuOpen()
    {
        isMenuOpen = true;
        var animEx = exitMenu.GetComponent<Animation>();
        exitMenu.transform.SetAsLastSibling();
        animEx.Play("Fade In");
        mainMenu = false;
    }

    //Closes the exit menu
    public void exitMenuClose()
    {
        isMenuOpen = false;
        var animEx = exitMenu.GetComponent<Animation>();
        animEx.Play("Fade out");
        mainMenu = true;
    }

    //Opens the select menu
    public void levelSelectOpen()
    {
        isMenuOpen = true;
        var animEx = levelSelect.GetComponent<Animation>();
        exitMenu.transform.SetAsLastSibling();
        animEx.Play("Fade In");
        mainMenu = false;
    }

    //Closes the select menu
    public void levelSelectClose()
    {
        isMenuOpen = false;
        var animEx = levelSelect.GetComponent<Animation>();
        animEx.Play("Fade out");
        mainMenu = true;
    }

    //Opens selected level
    public void levelSelectGo()
    {
        string selectedLevel = "Level" + selectedLevelInt;
        levelSelectClose();
        TransitionManager.TransitionToLevel(selectedLevel, menuBar, title, TransScript);
    }

    //Exit Game
    public void exitGame()
    {
        Application.Quit();
    }

    //Open Options
    public void openOptions()
    {
        isMenuOpen = true;
        OptionsMenu.gameObject.GetComponent<Animation>().Play("Fade In");
        mainMenu = false;
        OptionsMenu.transform.SetAsLastSibling();
    }

    //Close Options
    public void closeOptions()
    {
        isMenuOpen = false;
        OptionsMenu.gameObject.GetComponent<Animation>().Play("Fade out");
        mainMenu = true;
    }


}

