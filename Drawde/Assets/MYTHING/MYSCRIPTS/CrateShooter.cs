using UnityEngine;
using System.Collections;

public class CrateShooter : MonoBehaviour {


    public GameObject shootingPoint = null;
    public GameObject Crate = null;
    public int dropSpeed = 5000;
    public int dropCount = 0;
    private int TotalDropCount = 0;
    private float playSpeed;
    public GameObject latestCrate;
    public GameObject previousCrate;


    private void Drop()
    {
        dropCount += 1;
        TotalDropCount += 1;
        GameObject objects = Instantiate(Crate, transform.position, transform.rotation) as GameObject;
        objects.GetComponent<Rigidbody>().AddForce(transform.forward * dropSpeed);
        transform.position += new Vector3(0, 1f, 0);
        objects.name = dropCount + "block";
        objects = latestCrate;
        //objects.velocity = Spawn.transform.TransformDirection(new Vector3(0,0,dropSpeed));

    }

    public void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), TotalDropCount.ToString());
    }

    void OnCollisionEnter(Collision c)
    {

    }

    void Start()
    {
        dropCount = 0;
        TotalDropCount = 0;
        Time.timeScale = 1f;
    }

    void Update()
    {
        previousCrate = GameObject.Find(dropCount - 1 + "block");
        //Debug.Log(previousCrate);
        if (shootingPoint != null)
        {
            transform.LookAt(shootingPoint.transform);
            Debug.DrawLine(transform.position, shootingPoint.transform.position);
        }
        if(Time.timeScale != 0f)
            if (Input.GetMouseButtonDown(0))
            {
                Drop();
                CrateDropper playerScript = shootingPoint.GetComponent<CrateDropper>();
                playerScript.moveSpeed += 0.5f;
                shootingPoint.transform.position += new Vector3(0, 1f, 0);

            }
    }
}