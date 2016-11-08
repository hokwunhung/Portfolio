using UnityEngine;
using System.Collections;

public class KillPlayerScript : MonoBehaviour {

    public Player player;

	void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == "Player")
        {
            Destroy(c.gameObject);
            player.health = 0;
        }
    }
}
