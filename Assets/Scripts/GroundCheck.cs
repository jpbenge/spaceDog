using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	Dog dog;
	// Use this for initialization
	void Start () {
		dog = transform.parent.GetComponent<Dog>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == 8)
		{
			dog.Grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == 8)
		{
			dog.Grounded = false;
		}
	}

	void OnTriggerEnter2D(Collider2D	 other)
	{
		if (other.gameObject.layer == 8)
		{
			if (dog.Grounded == false)
			{
				dog.Grounded = true;
				dog.SendMessage("OnLand", SendMessageOptions.RequireReceiver);
			}
		}
	}
}
