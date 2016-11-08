using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour
{
	public float moveSpeed = 5;
	public bool toggleGUI;
	private float walkDist;
    Vector3 newPosition;
	private bool foundTrigger = false;
	//Rigidbody m_Rigidbody;
	Animator m_Animator;
	private float forwardAmount;
	Vector3 move;
	private bool inspecting;
	private GameObject floor;
	private Rect windowRect = new Rect((Screen.width-100)/2, (Screen.height-50)/2, 120, 50);
	public bool characterGUI;
	public GameObject clickedObject;
	public GameObject locked;

	void OnGUI() 
	{
		if(toggleGUI == true)
			windowRect = GUI.Window(0, windowRect, DoMyWindow, clickedObject.name);
	//	if(characterGUI == true)
	//		characterRect = GUI.Window(0, characterRect, CharacterWindow, "Edward");
	}
	void DoMyWindow(int windowID) 
	{
		if(GUI.Button(new Rect(10, 20, 100, 20), "Inspect"))
		{
			if(foundTrigger)
				GameObject.Destroy(GameObject.FindGameObjectWithTag("Lock"));
			else
			{
				GUI.Label (new Rect((Screen.width-100)/2, (Screen.height-20)/2, 100, 20), "Key is not here.");
			}

		}
		GUI.DragWindow();
	}
	void CharacterWindow(int windowID)
	{
		GUI.Button(new Rect(10,20,100,20), "Inventory");
		GUI.DragWindow();
	}
    void Start()
    {
        newPosition = transform.position;
		m_Animator = GetComponent<Animator>();
		//m_Rigidbody = GetComponent<Rigidbody>();
		//forwardAmount = Mathf.Abs((transform.position.normalized.x-newPosition.normalized.x)+(transform.position.normalized.z-newPosition.normalized.z));
		forwardAmount = walkDist;
    }
    void Update()
    {
		//m_Animator.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.smoothDeltaTime);
		//forwardAmount = Mathf.Abs((transform.position.normalized.x-newPosition.normalized.x)+(transform.position.normalized.z-newPosition.normalized.z));
		forwardAmount = Vector3.Distance (transform.position.normalized, newPosition.normalized);
		m_Animator.SetFloat("Forward", forwardAmount, 0.1f, moveSpeed*Time.deltaTime);
		transform.LookAt (newPosition);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
				if (hit.collider.tag == "Floor" && toggleGUI == false)
				{
                	newPosition = hit.point;
					Debug.Log (gameObject);
					walkDist = hit.distance;

				}
				else
					Debug.Log ("Unable to move.");
            }
        }
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log ("right clicked");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				foundTrigger = false;
				if (hit.collider.tag == "Clickable" && hit.distance < 120)
				{
					Debug.Log ("Clicked an object.");
					toggleGUI = true;
					clickedObject = hit.collider.gameObject;
					Debug.Log (clickedObject.name);
					if(hit.collider.isTrigger)
					{
						Debug.Log ("found trigger");
						foundTrigger = true;
					}
					else
						foundTrigger = false;
				}
				else
				{
					foundTrigger = false;
					clickedObject = null;
					toggleGUI = false;
				}
			}
		}

    }
}