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
    [SerializeField]
    private Vector2 moonGrav = new Vector2(0, -3.3f);
    [SerializeField]
    private Vector2 earthGrav = new Vector2(0, -9.8f);
    [SerializeField]
    private float gravityScale = 1f;

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

    public void Start()
    {
        SetGravity(gravityState);
    }

	public void Apply(Rigidbody2D r)
    {
        r.AddForce(Current * gravityScale);
    }
}
