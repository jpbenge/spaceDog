using UnityEngine;
using System.Collections;

public class SinMovement : MonoBehaviour {

	[SerializeField]
	private float speed = 1,distance = 5;
	private Vector3 startPosition;
	private float verticalPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		verticalPosition = (startPosition.y) + Mathf.Sin(Time.time);
		transform.position = new Vector3(startPosition.x,verticalPosition,0);
	}
}
