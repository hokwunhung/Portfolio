using UnityEngine;
using System.Collections;

public class HealthBar : Player 
{

	public Texture2D healthBar = null;
	private float modifier = 1f;
	public Rect position = new Rect(10,20,200,20);

	// Update is called once per frame
	public void OnGUI()
	{
		if (healthBar != null)
		{
			position.width = health * modifier;
			GUI.DrawTexture(position, healthBar);
		}
	}
	//private void SpaceShipDamage (int damage)
	//{
	//	health -= damage;
	//}
}
