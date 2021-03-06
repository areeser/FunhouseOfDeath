﻿using UnityEngine;
using System.Collections;

public class ShootTrampoline : MonoBehaviour {
    public GameObject tramp;
    public float initPos = 1.0f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float yOffset = -0.25f;
        if (LockPowers.TrampolineUnlocked && Input.GetMouseButtonDown(0) && (!gameObject.GetComponent<PlayerMovement>().trampJump)) {
            Destroy(GameObject.FindGameObjectWithTag("Trampoline"));
            Vector3 vect = gameObject.transform.position;
            if (gameObject.GetComponent<PlayerMovement>().facingRight)
            {
                vect += new Vector3(initPos, yOffset, 0);
            }
            else {
                vect += new Vector3(-initPos, yOffset, 0);
            }
            Instantiate(tramp, vect, new Quaternion());    
        }
    }
}
