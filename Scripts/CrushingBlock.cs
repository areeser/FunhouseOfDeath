using UnityEngine;
using System.Collections;

public class CrushingBlock : MonoBehaviour {
    public bool up = true;
    public int screenPoint = 0;
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
        if (screenPoint == cam.GetComponent<CameraMovement>().points) {
            gameObject.transform.Translate(0, speed * Time.deltaTime, 0);
        }
	}
}
