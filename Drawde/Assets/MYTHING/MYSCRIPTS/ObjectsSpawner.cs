using UnityEngine;
using System.Collections;

public class ObjectsSpawner : GameManager 
{


	public GameObject Player = null;
	public GameObject THING = null;
	public int dropAmount = 1;
	public int dropSpeed = 5000;
	public float reloadTime = 3;
	private bool reloading = false;
	private int dropCount = 0;
	private const int maxDrop = 6;
	public float shootDelay = 3;
	private bool shot = false;
	private int TotalDropCount = 0;
	public int LevelUp = 5;


	private void Drop()
	{
		dropAmount -= 1;
		dropCount += 1;
		TotalDropCount += 1;
		GameObject objects = Instantiate(THING, transform.position, transform.rotation) as GameObject;
		objects.GetComponent<Rigidbody>().AddForce(transform.forward * dropSpeed);
		//objects.velocity = Spawn.transform.TransformDirection(new Vector3(0,0,dropSpeed));
		Debug.Log (shootDelay);
	}

	public void OnGUI()
	{
		GUI.Label (new Rect (Screen.width - 100,0,100,50), TotalDropCount.ToString());
	}
/*
	private void Reload()
	{
		if (startReloadTime == 0 || dropAmount < level)
		{
			startReloadTime += Time.deltaTime;
		}
		if (startReloadTime == currentReloadTime)
		{
			dropAmount ++;
		}
		else
			startReloadTime = 0;
	}
*/
	private IEnumerator ShootDelay()
	{
		yield return new WaitForSeconds(shootDelay);
		shot = false;
	}
	private IEnumerator ReloadDelay()
	{
		yield return new WaitForSeconds (reloadTime);
		dropAmount += 1;
		reloading = false;

	}

	protected override void Update()
	{
		transform.LookAt(Player.transform);
		if (dropAmount > 0 && !shot)
		{
			shot = true;
			StartCoroutine(ShootDelay());
			Drop ();

		}

		if (dropAmount == 0 && !reloading) 
		{
			reloading = true;
			StartCoroutine (ReloadDelay ());
		}
		if (dropCount == LevelUp)
		{
			shootDelay -=0.5f;
			reloadTime -= 0.5f;
			dropCount = 0;
		}
		if (shootDelay < 0.5f)
			shootDelay = 0.5f;
		if (reloadTime < 0.5f)
			reloadTime = 0.5f;
	}
}