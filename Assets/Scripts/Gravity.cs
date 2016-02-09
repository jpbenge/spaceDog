using UnityEngine;
using System.Collections;

public enum GravityState
{
	Earth,
	Moon,
	Zero
};

public class Gravity : MonoBehaviour {

    [SerializeField]
	private GravityState gravityState = GravityState.Earth;
	private Vector2 currentGravity;
    private Vector2 moonGrav = new Vector2(0, -3.3f);
    private Vector2 earthGrav = new Vector2(0, -9.8f);

    public GravityState GravityState
    {
        get { return gravityState; }
        set { SetGravity(value); }
    }

    public Vector2 Current
    {
        get { return currentGravity; }
        set { currentGravity = value; }
    }

    void Start()
    {
    	SetGravity(GravityState.Earth);
    }

    private void SetGravity(GravityState gstate)
    {
        gravityState = gstate;

        switch (GravityState)
        {
            case GravityState.Moon:
                Current = moonGrav;
                break;
            case GravityState.Earth:
                Current = earthGrav;
                break;
            default:
                Current = Vector2.zero;
                break;
        }
    }

	public void Apply(Rigidbody2D r)
    {
        r.AddForce(Current);
    }
}
