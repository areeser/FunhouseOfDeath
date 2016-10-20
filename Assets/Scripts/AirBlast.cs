using UnityEngine;
using System.Collections;

public class AirBlast : MonoBehaviour {
    public float airBlastForce = 1000.0f;
    public bool facingRight;
    public bool blast = false;
    public float timer = 0.0f;
    public float boostTime = 0.5f;
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        facingRight = gameObject.GetComponent<PlayerMovement>().facingRight;
        if (!blast)
        {
            if (facingRight && Input.GetMouseButtonDown(1))
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-airBlastForce, 0), ForceMode2D.Force);
                blast = true;
            }
            else if (!facingRight && Input.GetMouseButtonDown(1))
            {
                blast = true;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(airBlastForce, 0), ForceMode2D.Force);
            }
        }
        else {
            timer += Time.deltaTime;
            if (timer >= boostTime)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, gameObject.GetComponent<Rigidbody2D>().velocity.y);
                blast = false;
                timer = 0;
            }
            else if (Input.GetMouseButtonUp(1)) {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            }
        }
    }
}
