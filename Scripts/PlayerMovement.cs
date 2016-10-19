using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour {
	
	//	<Sprite Variables>
	public Sprite[] playerAnimation = new Sprite[4];
	private int playerSpriteAnimationPos = 0;
	private int minSprite, maxSprite;
	public float delay = 0.1f;
	private float timer = 0f;
	public GameObject playerSprite;
    //	</Sprite Variables>
	public float speed = 10.0f;
    public float jumpForce = 10.0f;
    public float bounceForce = 1000.0f;
    public bool crushing = false; 
    public static bool trampJump = false;
    public static bool touchingGround;
    public static bool facingRight;
    public Collision2D ColliInfo;
    public Vector2 vect;
    public Vector2 playerPosition;
    public double mousePos;
    public Camera cam;
	
	void UpdateSpriteAnimation(string command) {
			char[] delim = {' ',','};
			if (command == "INCREMENT") {
				timer -= Time.deltaTime;
				if (timer <= 0) {
					playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = 
						playerAnimation[playerSpriteAnimationPos++];
					timer = delay;
					if (playerSpriteAnimationPos > maxSprite)
						playerSpriteAnimationPos = minSprite;
				}
			} else if (command == "RESET") {
				playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = 
						playerAnimation[0];
			} else if (command.Split(delim)[0] == "RANGE") {
				minSprite = Convert.ToInt32(command.Split(delim)[1]);
				maxSprite = Convert.ToInt32(command.Split(delim)[2]);
			}
			
	}
	
	// Use this for initialization
	void Start () {
		playerAnimation[0] = Resources.Load<Sprite>("Slime1");
		playerAnimation[1] = Resources.Load<Sprite>("Slime2");;
		playerAnimation[2] = Resources.Load<Sprite>("Slime3");;
		playerAnimation[3] = Resources.Load<Sprite>("Slime2");;
		playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
		playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = playerAnimation[0];
		minSprite = 0;
		maxSprite = playerAnimation.Length-1;
			
        touchingGround = true;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
			if (touchingGround)
				UpdateSpriteAnimation("INCREMENT");
        }
        else if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
			if (touchingGround)
				UpdateSpriteAnimation("INCREMENT");
        }
		else {
			if (touchingGround)
				UpdateSpriteAnimation("RESET");
		}
        if (!(touchingGround)) {
            //OnCollisionEnter2D(ColliInfo);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
        //vect = gameObject.GetComponent<Rigidbody2D>().velocity;
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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bounceForce), ForceMode2D.Force);
            Destroy(GameObject.FindGameObjectWithTag("Trampoline"));
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
