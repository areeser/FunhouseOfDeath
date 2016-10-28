using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Player") {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().ChangeScene("LevelSelect");
        }
    }
}
