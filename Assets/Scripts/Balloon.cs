using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
    public bool balloonOut;
    Transform playerTransform;
    public float positionY;
    public float updatePositionY;
    public float speed = 10.0f;
	// Use this for initialization
	void Start () {
        positionY = gameObject.transform.position.y;
        updatePositionY = gameObject.transform.position.y;
        balloonOut = false;
	}
	
	// Update is called once per frame
	void Update () {
        positionY = gameObject.transform.position.y;
        updatePositionY = gameObject.transform.position.y;

        if (Input.GetKeyDown(KeyCode.X) && gameObject.GetComponent<PlayerMovement>().touchingGround)
        {
            balloonOut = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            balloonOut = false;
        }
        if (balloonOut) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            gameObject.transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
        }

	}
}
