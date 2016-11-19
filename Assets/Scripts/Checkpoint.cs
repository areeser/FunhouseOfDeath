using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

    public int point = 0;

	// Use this for initialization
	void Start () {
        if (GameManager.checkPoint) {
            GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
           
            GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,
                                                                                         GameObject.FindGameObjectWithTag("MainCamera").transform.position.z);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().points = point;
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Player") {
            GameManager.checkPoint = true;
            Destroy(gameObject);
        }
    }
}
