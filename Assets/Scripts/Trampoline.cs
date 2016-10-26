using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

    public bool tempTramp = true;
    public bool bounceUp = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D colliInfo)
    {
        if (colliInfo.gameObject.tag == "Player" && tempTramp)
        {
            Destroy(gameObject);
        }
    }
}
