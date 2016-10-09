using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float bounceForce = 1000.0f;
    public static bool trampJump = false;
    public static bool touchingGround;
    public static bool facingRight;
    public Collision2D ColliInfo;
    public Vector2 vect;
    public Vector2 playerPosition;
    public double mousePos;
    Camera cam;
	// Use this for initialization
	void Start () {
        touchingGround = true;
        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        playerPosition = cam.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        mousePos = Input.mousePosition.x / cam.pixelWidth;

        if (playerPosition.x - mousePos >= 0) {
            facingRight = false;
        } else if (playerPosition.x - mousePos < 0) {
            facingRight = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));          
        }
        else if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));            
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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Force);
        }
        if (colliInfo.gameObject.tag == "Enemy") {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnCollisionExit2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground") {
            touchingGround = false;
        }
    }
}
