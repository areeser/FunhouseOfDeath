using UnityEngine;
using System.Collections;

public class AirBlast : MonoBehaviour {
    public float airBlastForce = 1000.0f;
    public bool facingRight;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        facingRight = PlayerMovement.facingRight;
        if (facingRight && Input.GetMouseButtonDown(1)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-airBlastForce, 0), ForceMode2D.Force);
        }
        else if (!facingRight  && Input.GetMouseButtonDown(1)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(airBlastForce, 0), ForceMode2D.Force); }
	    }
}
