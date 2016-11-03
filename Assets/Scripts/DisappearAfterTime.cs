using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DisappearAfterTime : MonoBehaviour {
    
	public float delay = 5.0f;
    // Use this for initialization
    void Start() {}

    // Update is called once per frame
    void Update() {
		//gameObject.GetComponent<PlayerMovement>().touchingGround = 
		
		delay -= Time.deltaTime;
		if (delay <= 0) {
			Destroy(gameObject);
		}
	}
}
