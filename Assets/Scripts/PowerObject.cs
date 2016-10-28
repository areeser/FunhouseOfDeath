using UnityEngine;
using System.Collections;

public class PowerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colliInfo) {
        if (colliInfo.gameObject.tag == "Player") {
            if (gameObject.tag == "TrampPower")
            {
                LockPowers.TrampolineUnlocked = true;
            }
            else if (gameObject.tag == "AirBlastPower") {
                LockPowers.AirBlastUnlocked = true;
            }
            else
            {
                LockPowers.BalloonUnlocked = true;
            }
            Destroy(gameObject);
        }
    }
}
