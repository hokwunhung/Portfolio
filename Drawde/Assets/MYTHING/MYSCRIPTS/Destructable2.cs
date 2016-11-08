using UnityEngine;
using System.Collections;

public class Destructable2 : MonoBehaviour
{
	void Start ()
	{	 
		Destroy(gameObject, 3);
	}
}