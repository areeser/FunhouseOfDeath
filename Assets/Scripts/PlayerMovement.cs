using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour {
	
	//	<Sprite Variables>
	private Sprite[] playerAnimation = new Sprite[8];
	private int playerSpriteAnimationPos = 0;
	private int minSprite, maxSprite, prevMinSprite, prevMaxSprite;
	public float delay = 0.1f;
	private float timer = 0f;
	private bool playerSpriteLoop = true; 
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
			char[] delims1 = {'|'};
			char[] delims2 = {' ',','};
			String[] commandList = command.Split(delims1);
			for (int i=0; i<commandList.Length; i++) {
				command = commandList[i];
				if (command == "INCREMENT") {
					timer -= Time.deltaTime;
					if (timer <= 0) {
						playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = 
							playerAnimation[playerSpriteAnimationPos++];
						timer = delay;
						if (playerSpriteAnimationPos > maxSprite)
							if (playerSpriteLoop)
								playerSpriteAnimationPos = minSprite;
							else
								playerSpriteAnimationPos = maxSprite;
							
						if (minSprite != prevMinSprite || maxSprite != prevMaxSprite) {
							playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = 
								playerAnimation[0];
							playerSpriteAnimationPos = minSprite;
							timer = 0;
						}
						prevMinSprite = minSprite;
						prevMaxSprite = maxSprite;
					}
				} else if (command == "RESET") {
					playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = 
							playerAnimation[0];
					playerSpriteAnimationPos = minSprite;
					timer = 0;
				} else if (command.Split(delims2)[0] == "RANGE") {
					minSprite = Convert.ToInt32(command.Split(delims2)[1]);
					maxSprite = Convert.ToInt32(command.Split(delims2)[2]);
				} else if (command.Split(delims2)[0] == "DELAY") {
					delay = float.Parse(command.Split(delims2)[1]);
				} else if (command == "LOOP") {
					playerSpriteLoop = true;
				} else if (command == "NOLOOP") {
					playerSpriteLoop = false;
				}
			}
	}
	
	// Use this for initialization
	void Start () {
		//Walking
		playerAnimation[0] = Resources.Load<Sprite>("Slime2");
		playerAnimation[1] = Resources.Load<Sprite>("Slime3");
		playerAnimation[2] = Resources.Load<Sprite>("Slime2");
		playerAnimation[3] = Resources.Load<Sprite>("Slime1");
		//Jumping
		playerAnimation[4] = Resources.Load<Sprite>("Slime4");
		playerAnimation[5] = Resources.Load<Sprite>("Slime5");
		playerAnimation[6] = Resources.Load<Sprite>("Slime6");
		playerAnimation[7] = Resources.Load<Sprite>("Slime7");
		
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
				UpdateSpriteAnimation("RANGE 0,3|DELAY 0.1|LOOP|INCREMENT");
        }
        else if (Input.GetKey(KeyCode.A)) {
            gameObject.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
			if (touchingGround)
				UpdateSpriteAnimation("RANGE 0,3|DELAY 0.1|LOOP|INCREMENT");
        }
		else {
			if (touchingGround)
				UpdateSpriteAnimation("RESET");
		}
        if (!(touchingGround)) {
			UpdateSpriteAnimation("RANGE 4,7|DELAY 0.025|NOLOOP|INCREMENT");
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
