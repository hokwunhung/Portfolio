using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour {

    private int currentcount;
    public int deathcount = 2;
    private DropperManager manager;
    public Player player;

	void OnCollisionEnter(Collision c)
    {
        currentcount++;
        Debug.Log(currentcount);
    }

    void start()
    {
        currentcount = 0;

    }

    void Update()
    {
        if (currentcount==deathcount)
        {
            player.health = 0;
            Debug.Log("health = 0");
        }
    }
}
