using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
	Dog dog;
	float h;
	float v;
	bool run;
	bool jump;

	// Use this for initialization
	void Start () {
		dog = gameObject.GetComponent<Dog>();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputs();
		SendInputs(dog);
	}

	void GetInputs()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		run = Input.GetButton("Run");
		jump = Input.GetButton("Jump");
	}
	void SendInputs(Dog d)
	{
		d.h = h;
		d.v = v;
		d.run = run;
		d.jump = jump;
	}
}
