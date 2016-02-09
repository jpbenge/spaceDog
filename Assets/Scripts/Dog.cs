using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Dog : MonoBehaviour {
	public Animator animController;

	private GameManager gameManager;
	private bool grounded;
	public bool Grounded
	{
		get { return grounded; }
        set { grounded = value; }
	}

	private Gravity gravity;
	public Gravity Gravity
    {
        get { return gravity; }
    }
	//input variables
	public float h;
	public float v;
	public bool run;
	public bool jump;
	void Start()
	{
		animController = GetComponent<Animator>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gravity = GetComponent<Gravity>();
		Spawn();
	}

	void Spawn()
	{

	}

	void Update ()
    {
        animController.SetFloat("hVal",h);
        animController.SetBool("run",run);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(h*4, 0));
        if (jump)
        {
        	
        	if (grounded)
        	{
        		GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200f));
        		grounded = false;
        		animController.SetBool("jump",true);
        	}
        }
    }
    void FixedUpdate ()
    {
    	gravity.Apply(GetComponent<Rigidbody2D>());
    }

    void OnLand()
    {
    	animController.SetBool("jump",false);
    }
}
