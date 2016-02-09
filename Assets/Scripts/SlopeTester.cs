using UnityEngine;
using System.Collections;

public class SlopeTester : MonoBehaviour {

	public GameObject slopeTest1;
	public GameObject slopeTest2;
	Dog dog;
	LayerMask mask = -8;
	// Use this for initialization
	void Start () {
		dog = gameObject.GetComponent<Dog>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		if (slopeTest1)
		{
        	Gizmos.DrawWireSphere(slopeTest1.transform.position, 0.01f);
      		Gizmos.DrawRay(slopeTest1.transform.position, new Vector3(0, -0.5f,0));
      		Gizmos.color = Color.blue;
      		Gizmos.DrawRay(slopeTest1.transform.position, new Vector3(0, 0.5f,0));
      	}
        Gizmos.color = Color.green;
        if (slopeTest2)
        {
        	Gizmos.DrawWireSphere(slopeTest2.transform.position, 0.01f);
        	Gizmos.DrawRay(slopeTest2.transform.position, new Vector3(0, -0.5f,0));
      		Gizmos.color = Color.blue;
      		Gizmos.DrawRay(slopeTest2.transform.position, new Vector3(0, 0.5f,0));
      	}
	}

	void FixedUpdate() {
		Vector2 pos1 = Vector2.zero;
		Vector2 pos2 = Vector2.zero;
		RaycastHit2D hit1 = Physics2D.Raycast(slopeTest1.transform.position, -Vector2.up,0.5f, mask.value);
		if (hit1.collider != null) {
			pos1 = hit1.point;
		}
		else
		{
			hit1 = Physics2D.Raycast(slopeTest1.transform.position, Vector2.up,0.5f, mask.value);
			if (hit1.collider != null) {
				pos1 = hit1.point;
			}
		}
		RaycastHit2D hit2 = Physics2D.Raycast(slopeTest2.transform.position, -Vector2.up,0.5f, mask.value);
		if (hit2.collider != null) {
			pos2 = hit2.point;
		}
		else
		{
			hit2 = Physics2D.Raycast(slopeTest2.transform.position, Vector2.up,0.5f, mask.value);
			if (hit2.collider != null) {
				pos2 = hit2.point;
			}
		}
		//print(pos1);
		//print(pos2);
		if (dog.Grounded && pos1 != Vector2.zero && pos2 != Vector2.zero)
		{
			Vector2 v = pos1-pos2;
			Vector2 pos3 = new Vector2(-v.y/Mathf.Sqrt(v.x*v.x), v.x/Mathf.Sqrt(v.y*v.y))*1;
			Vector2 pos4 = new Vector2(-v.y/Mathf.Sqrt(v.x*v.x), v.x/Mathf.Sqrt(v.y*v.y))*-1;
			Vector2 v2 = pos3-pos4;
			float angle = Mathf.Atan2(v.x,v.y) * Mathf.Rad2Deg;
			//transform.Rotate(0, 0 ,angle);
			transform.localEulerAngles = new Vector3(0, 0, -angle-90);
		}
	}
}
