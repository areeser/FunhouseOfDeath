using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("TestLevel");
        }
	}
}
