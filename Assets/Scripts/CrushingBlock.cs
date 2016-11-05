using UnityEngine;
using System.Collections;

public class CrushingBlock : MonoBehaviour {
    public bool up = true;
    public bool stop = false;
    public int screenPointOne = 0;
    public int screenPointTwo = 0;
    public float speed = 10.0f;
    public Camera cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (!up) {
            speed = -speed;
        }
	}

    // Update is called once per frame
    void Update() {
        int points = cam.GetComponent<CameraMovement>().points;
        if (screenPointOne <= points && screenPointTwo >= points && !(stop)) {
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
	}

    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Ground")
        {
            stop = true;
        }
        if (colliInfo.gameObject.tag == "Crush") {
            stop = true;
        }
    }
}
