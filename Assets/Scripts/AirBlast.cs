using UnityEngine;
using System.Collections;

public class AirBlast : MonoBehaviour {
	public GameObject Confetti;
    public float airBlastForce = 1000.0f;
    public bool facingRight;
    public bool blast = false;
    public float timer = 0.0f;
    public float boostTime = 0.5f;
	public float confettiSpread = 1000f;
	public float confettiSpeed = 2500f;
	public int confettiCount = 50;
	// Use this for initialization
	void Start () {
        //Confetti = (GameObject)Resources.Load("Confetti");
    }

	void generateConfetti(bool direction) {
		float w =  transform.lossyScale.x;
		for (int i=0; i<confettiCount; i++) {
			GameObject confettiObject;
			if (direction)
				confettiObject = (GameObject)Instantiate(	Confetti, 
															new Vector2(transform.position.x+w,transform.position.y), 
															new Quaternion()); 
			else
				confettiObject = (GameObject)Instantiate(	Confetti, 
															new Vector2(transform.position.x-w,transform.position.y), 
															new Quaternion()); 
				
			confettiObject.GetComponent<SpriteRenderer>().color = new Color(	Random.value,
																				Random.value,
																				Random.value);
			if (direction) {
				Vector2 randomVelocity = new Vector2(confettiSpeed*Random.value,confettiSpread*(Random.value*2.0f-1.0f));
				confettiObject.gameObject.GetComponent<Rigidbody2D>().AddForce(randomVelocity,ForceMode2D.Force);
			} else {
				Vector2 randomVelocity = new Vector2(-confettiSpeed*Random.value,confettiSpread*(Random.value*2.0f-1.0f));
				confettiObject.gameObject.GetComponent<Rigidbody2D>().AddForce(randomVelocity,ForceMode2D.Force);
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
        if (LockPowers.AirBlastUnlocked)
        {
            facingRight = gameObject.GetComponent<PlayerMovement>().facingRight;
            if (!blast)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    gameObject.GetComponent<PlayerMovement>().canMove = false;
                    if (facingRight)
                    {
                        generateConfetti(true);
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-airBlastForce, 0), ForceMode2D.Force);
                        blast = true;
                    }
                    else if (!facingRight)
                    {
                        generateConfetti(false);
                        blast = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(airBlastForce, 0), ForceMode2D.Force);
                    }
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer >= boostTime)
                {
                    gameObject.GetComponent<PlayerMovement>().canMove = true;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                    blast = false;
                    timer = 0;
                }
                else if (Input.GetMouseButtonUp(1))
                {
                    gameObject.GetComponent<PlayerMovement>().canMove = true;
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
                }
            }
        }
    }
}
