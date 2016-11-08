using UnityEngine;
using System.Collections;

public class DropperManager : MonoBehaviour
{

    private bool togglePGUI;
    private bool toggleDGUI;
    public bool paused;
    public bool death;
    public Player player;
    private Rect windowRect = new Rect((Screen.width - 100) / 2, (Screen.height - 50) / 2, 120, 80);


    void OnGUI()
    {
        if (togglePGUI == true)
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "Menu");
        //	if(characterGUI == true)
        //		characterRect = GUI.Window(0, characterRect, CharacterWindow, "Edward");
    }

    void DoMyWindow(int windowID)
    {
        if (!death)
        {
            if (GUI.Button(new Rect(10, 20, 100, 20), "Unpause"))
            {
                paused = false;
                Time.timeScale = 1f;
            }
            if (GUI.Button(new Rect(10, 50, 100, 20), "Main Menu"))
            {
                paused = false;
                Time.timeScale = 1f;
                Application.LoadLevel("MainMenu");
            }
            GUI.DragWindow();
        }
        if(death)
        {
            if (GUI.Button(new Rect(10, 20, 100, 20), "Retry?"))
            {
                Time.timeScale = 1f;
                death = false;
                Application.LoadLevel(Application.loadedLevel);      
            }
            if(GUI.Button(new Rect(10,40,100,20),"Main Menu"))
            {
                death = false;
                Time.timeScale = 1f;
                Application.LoadLevel("MainMenu");
            }
            if (GUI.Button(new Rect(10,60,100,20), "Quit"))
            {
                death = false;
                Application.Quit();
            }
            GUI.DragWindow();
        }
    }

    public void OnPauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
    }

    public void OnDeadScreen()
    {
        death = true;
        Time.timeScale = 0f;
        togglePGUI = true;
    }

    // Use this for initialization
    void Start()
    {
        paused = false;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            togglePGUI = false;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPauseGame();
                togglePGUI = true;
            }
        }
        if(player.health <= 0)
        {
            OnDeadScreen();
            togglePGUI = true;
            Debug.Log("triggering!");
        }
    }
}
