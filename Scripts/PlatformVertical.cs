using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlatformVertical : MonoBehaviour {
    
    public float speed = 5.0f;
	public float delay = 5.0f;
	public float timer;
	public float startX, startY, startZ;

    // Use this for initialization
    void Start() {
		startX = transform.position.x;
		startY = transform.position.y;
		startZ = transform.position.z;
		timer = delay;
    }

    // Update is called once per frame
    void Update() {
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-speed);
		timer -= Time.deltaTime;
		if (timer <= 0) {
			transform.position = new Vector3(startX, startY, startZ);	
			//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -speed), ForceMode2D.Force);		
			timer = delay;
		}
	}
}
