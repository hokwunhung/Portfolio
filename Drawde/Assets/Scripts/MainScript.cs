using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {

	private bool toggleGUI;
	private bool paused;
	private Rect windowRect = new Rect((Screen.width-100)/2, (Screen.height-50)/2, 120, 50);

	void OnGUI() 
	{
		if(toggleGUI == true)
			windowRect = GUI.Window(0, windowRect, DoMyWindow, "Menu");
		//	if(characterGUI == true)
		//		characterRect = GUI.Window(0, characterRect, CharacterWindow, "Edward");
	}

	void DoMyWindow(int windowID) 
	{
		if(GUI.Button(new Rect(10, 20, 100, 20), "Unpause"))
		{
			paused = false;
			Time.timeScale = 1f;
		}
		GUI.DragWindow();
	}

	protected void OnPauseGame ()
	{
		paused = true;
		Time.timeScale = 0f;
	}

	// Use this for initialization
	void Start () 
	{
		paused = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!paused)
		{
			toggleGUI = false;
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				OnPauseGame ();
				toggleGUI = true;
			}
		}
	}
}
