using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float bounceForce = 1000.0f;
    public static bool trampJump = false;
    public static bool touchingGround;
    public static bool facingRight = true;
    public Collision2D ColliInfo;
    public Vector2 vect;
	// Use this for initialization
	void Start () {
        touchingGround = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            facingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            facingRight = false;
        }
        if (!(touchingGround)) {
            OnCollisionEnter2D(ColliInfo);
        }
        else if (Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
        vect = gameObject.GetComponent<Rigidbody2D>().velocity;
    }
    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground") {
            touchingGround = true;
            trampJump = false;
        }
        if (colliInfo.gameObject.tag == "Trampoline") {
            touchingGround = false;
            trampJump = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Force);
        }
    }

    void OnCollisionExit2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground") {
            touchingGround = false;
        }
    }
}
