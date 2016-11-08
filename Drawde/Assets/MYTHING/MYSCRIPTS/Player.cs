using UnityEngine;
using System.Collections;

public class Player : GameManager 
{
	public int health = 100;
	private const int maxHealth = 100;
    public float jumpForce = 2000.0f;
    public bool jumping = false;
	public float playerSpeed = 10.0f;
    private DropperManager manager;

    //setups spawn
    
	private void OnCollisionEnter(Collision c) 
	{
		if (c.rigidbody != null && c.rigidbody.mass <= c.rigidbody.mass && c.rigidbody.velocity.y > 0)
			return;
		
		if (c.contacts[0].normal.y> 0.7f)
			jumping = false;

		if (c.gameObject.name == "Broo")
			health -= 50;
		if (c.gameObject.name == "Split shard")
			health -= 10;
	}
	
	protected void Start()
	{
		transform.position = new Vector3 (0,1,0);
        Time.timeScale = 1f;
	}

	
	protected override void Update()
    {
		if (health < 0)
			health = 0;
		else if (health <= 0)
		{
            Debug.Log("player is dead");
            Destroy(gameObject);


        }
		else if (health > maxHealth)
			health = maxHealth;

        transform.position -= new Vector3(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, 0);

    

        if (!jumping && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
            jumping = true;
        }
    }

	
}
