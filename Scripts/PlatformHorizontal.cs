using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlatformHorizontal : MonoBehaviour {
    
    public float speed = 5.0f;
	public float delay = 5.0f;
	public float timer;
	public float startX, startY, startZ;
	public bool collidingWithPlayer = false;

    // Use this for initialization
    void Start() {
		timer = delay;
    }

    // Update is called once per frame
    void Update() {
		//gameObject.GetComponent<PlayerMovement>().touchingGround = 
		
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0);
		timer -= Time.deltaTime;
		if (timer <= 0) {
			speed *= -1;
			timer = delay;
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (collidingWithPlayer)
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(	speed,
																			player.GetComponent<Rigidbody2D>().velocity.y);
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
