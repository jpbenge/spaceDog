using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Dog : MonoBehaviour {
	public Animator animController;

	private GameManager gameManager;
	private bool grounded;
    private bool reachedApex;
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
    [SerializeField]
    private float speed = 50f;
    private float curSpeed;
	public bool run;
	public bool jump;
    private Rigidbody2D rigidbody;
    private float startHeight;
    private float apex;
    [SerializeField]
    private float jumpHeight = 10f;
	void Start()
	{
		animController = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gravity = GetComponent<Gravity>();
		Spawn();
	}

	void Spawn()
	{
        reachedApex = true;
	}

	void Update ()
    {
        animController.SetFloat("hVal",h);
        animController.SetBool("run",run);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(h*4, 0));
        if (jump)
        {     	
        	Jump();
        }
        if (!grounded && !jump) {
            reachedApex = true;
        }
        if (!grounded)
            curSpeed = speed * 0.1f;
        else if (run)
            curSpeed = speed * 2.5f;
        else
            curSpeed = speed;
        rigidbody.AddForce(new Vector2(h*curSpeed,0));
    }
    void FixedUpdate ()
    {
    	gravity.Apply(GetComponent<Rigidbody2D>());
    }

    void OnLand()
    {
    	animController.SetBool("jump",false);
    }

    void Jump()
    {
        if (grounded)
        {
            startHeight = transform.position.y;
            apex = startHeight + jumpHeight;
            rigidbody.AddForce(new Vector2(0, 1000f));
            grounded = false;
            animController.SetBool("jump",true);
            reachedApex = false;
        }
        else if (!reachedApex && transform.position.y < startHeight + jumpHeight){
            rigidbody.AddForce(new Vector2(0, 400f));
        }
        else {
            reachedApex = true;
        }
    }
}
