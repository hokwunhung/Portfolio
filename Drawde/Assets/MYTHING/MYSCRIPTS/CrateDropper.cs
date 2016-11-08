using UnityEngine;
using System.Collections;

public class CrateDropper : MonoBehaviour {

    private int Xmove = 1;
    private float Ymove = 1f;
    public float moveSpeed;

	// Use this for initialization
	void Start ()
    {
        
    }
/*
    void OnCollisionEnter(Collision c)
    {
        ContactPoint contact = c.contacts[0];

        if (contact.otherCollider.gameObject.tag == "Cube")
        {
            transform.position += new Vector3(0, 1f, 0);
        }
    }
*/
    void OnTriggerEnter(Collider other)
    {
        Xmove *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Xmove * moveSpeed * Time.deltaTime, 0, 0);
    }
}
