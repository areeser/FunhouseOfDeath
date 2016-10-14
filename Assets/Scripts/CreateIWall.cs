using UnityEngine;
using System.Collections;

public class CreateIWall : MonoBehaviour {
    public GameObject iWall;
    public Vector3 playerPos;
    public float wallPos = 2.0f;
	// Use this for initialization
	void Start () {
	    
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().canCreateWall) {
            Vector3 vect = new Vector3(playerPos.x - wallPos, 0, 0);
            Instantiate(iWall, vect, new Quaternion());
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().canCreateWall = false;
        }
    }
}
