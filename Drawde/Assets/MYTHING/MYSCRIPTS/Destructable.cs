using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour 
{
	public GameObject BombShards;

	void OnCollisionEnter(Collision c)
	{ 
	
		if (BombShards)
		{
			Instantiate(BombShards, transform.position, transform.rotation);
		}
		
		Destroy(gameObject);
	}
}

