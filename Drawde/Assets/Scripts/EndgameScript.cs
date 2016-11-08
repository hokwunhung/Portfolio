using UnityEngine;
using System.Collections;

public class EndgameScript : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
    {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}