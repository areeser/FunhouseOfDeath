using UnityEngine;
using System.Collections;

public class PlatformHorizontal : MonoBehaviour {

    //public float speed = 5.0f;
    public Vector2 movement;
    public float delay = 5.0f;
	public float timer;
	//public float startX, startY, startZ;
	public bool collidingWithPlayer = false;

    // Use this for initialization
    void Start() {
		timer = delay;
    }

    // Update is called once per frame
    void Update() {
		//gameObject.GetComponent<PlayerMovement>().touchingGround = 
		
		gameObject.GetComponent<Rigidbody2D>().velocity = movement;
		timer -= Time.deltaTime;
		if (timer <= 0) {
			movement = -movement;
            if (collidingWithPlayer)
                GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(movement.x, -movement.y);
            timer = delay;
		}
	}
	void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Player") {
			collidingWithPlayer = true;
        }
	}
	void OnCollisionExit2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Player") {
			collidingWithPlayer = false;
        }
	}
}
