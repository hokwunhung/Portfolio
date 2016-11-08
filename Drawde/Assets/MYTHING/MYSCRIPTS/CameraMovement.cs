using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public CrateShooter crate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(crate.dropCount >= 5)
        {
            transform.position += new Vector3(0, 0.8f * Time.deltaTime, 0);
        }
	
	}
}
