using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

    public int deadcount = 2;
    private int currentcount = 0;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Ground")
        {
            currentcount++;
            Debug.Log(currentcount);
        }
    }


    public bool IsVisible;
	// Update is called once per frame
	void Update () {

        if (!IsVisible)
        {
            Debug.Log("can't see me");
        }

        if (currentcount>=deadcount)
        {
            Application.Quit();
        }
	
	}
}
