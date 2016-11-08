using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

    public CrateShooter shooter;
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public GameObject target = null;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(target);
        target = GameObject.Find(shooter.dropCount - 1 + "block");
        if (target)
        {
            
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.transform.position);
            Vector3 delta = target.transform.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}