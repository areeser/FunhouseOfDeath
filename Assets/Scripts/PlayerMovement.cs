using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 10.0f;
    public float jumpForce = 300.0f;

    public float bounceForce = 1000.0f;
    public float maxBounceForce = 1500.0f;
    public float bForceMod = 10.0f;
    public float yBounceForce;

    public bool crushing = false;
    public bool trampJump = false;
    public bool touchingGround = true;
    public bool facingRight;
    public Collision2D ColliInfo;
    public Vector2 vect;
    public Vector2 playerPosition;
    public double mousePos;
    public Camera cam;

    // Use this for initialization
    void Start() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        playerPosition = cam.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        mousePos = Input.mousePosition.x / cam.pixelWidth;

        if (gameObject.GetComponent<Balloon>().balloonOut == false)
        {
            if (playerPosition.x - mousePos >= 0)
            {
                facingRight = false;
            }
            else if (playerPosition.x - mousePos < 0)
            {
                facingRight = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            else if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            else
            {
            }
            if (!(touchingGround))
            {
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            }
        }
        yBounceForce = gameObject.GetComponent<Rigidbody2D>().velocity.y * bForceMod;
    }

    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground") {
            if (crushing) {
                SceneManager.LoadScene("GameOver");
            }
            touchingGround = true;
            trampJump = false;
        }
        if (colliInfo.gameObject.tag == "Trampoline") {
            touchingGround = false;
            trampJump = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            
            if (colliInfo.gameObject.GetComponent<Trampoline>().bounceUp)
            {
                float force = -yBounceForce + bounceForce;
                if (force >= maxBounceForce) {
                    force = maxBounceForce;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -yBounceForce + bounceForce), ForceMode2D.Force);
            }
            else
            {
                float force = -(yBounceForce + bounceForce);
                if (force >= maxBounceForce)
                {
                    force = maxBounceForce;
                }
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(yBounceForce + bounceForce)), ForceMode2D.Force);
            }
            if (colliInfo.gameObject.GetComponent<Trampoline>().tempTramp) {
                Destroy(colliInfo.gameObject);
            }
        }
        if (colliInfo.gameObject.tag == "Enemy") {
            SceneManager.LoadScene("GameOver");
        }
        if (colliInfo.gameObject.tag == "Crush") {
            crushing = true;
            if (touchingGround) {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (colliInfo.gameObject.tag == "TrampPower")
        {
            LockPowers.TrampolineUnlocked = true;
        }
        if (colliInfo.gameObject.tag == "BalloonPower")
        {
            LockPowers.BalloonUnlocked = true;
        }
        if (colliInfo.gameObject.tag == "AirBlastPower")
        {
            LockPowers.AirBlastUnlocked = true;
        }
        gameObject.GetComponent<Balloon>().balloonOut = false;
    }

    void OnCollisionExit2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground") {
            touchingGround = false;
        }
        if (colliInfo.gameObject.tag == "Crush")
        {
            crushing = false;
        }
    }
}
