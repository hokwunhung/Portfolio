using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour 
{

	// Use this for initialization
	void OnGUI () 
	{
		// Make a background box
		GUI.Box(new Rect((Screen.width-200)/2,(Screen.height-150)/2,200,100), "Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect((Screen.width-200)/2, (Screen.height-150) / 2+20, 200,20), "Play Drawde")) 
		{
			Application.LoadLevel("BoxCrashLevel");
		}
        if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 150) / 2 + 40, 200, 20), "Play CrateDropper"))
        {
            Application.LoadLevel("CrateDropperLevel");
        }
        if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 150) / 2 + 60, 200, 20), "Play Escape(Prototype)"))
        {
            Application.LoadLevel("Stage 1");
        }
        if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 150) / 2 + 80, 200, 20), "Quit"))
        {
            Application.Quit();
        }
    }

    void Start()
    {
        Time.timeScale = 1f;

    }
}
