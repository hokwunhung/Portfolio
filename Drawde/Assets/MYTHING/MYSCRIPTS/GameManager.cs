using UnityEngine;
using System.Collections;
using Destruction.Standard;

public class GameManager : MonoBehaviour 
{
	private Shard[] pieces;
	private float eraseCurrentTime = 0.0f;
	public float eraseTime = 3.0f;
	public PhysicMaterial bouncy = null;
	
	void shardThing()
	{
	
		pieces = GameObject.FindObjectsOfType<Shard>();
		foreach (Shard shard in pieces)
			{
				Destroy(shard.gameObject);
			}
		
		eraseCurrentTime = 0.0f;
		
	}
	
	protected virtual void Update () 
	{
		eraseCurrentTime += Time.deltaTime;
		
		if (eraseCurrentTime >= eraseTime)
		{
			shardThing();
		}
		
	}
}
