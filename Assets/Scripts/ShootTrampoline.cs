using UnityEngine;
using System.Collections;

public class ShootTrampoline : MonoBehaviour {
    public GameObject tramp;
    public float initPos = 1.0f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Z) && (!PlayerMovement.trampJump)) {
            Destroy(GameObject.FindGameObjectWithTag("Trampoline"));
            Vector3 vect = gameObject.transform.position;
            if (PlayerMovement.facingRight)
            {
                vect += new Vector3(initPos, 0, 0);
            }
            else {
                vect += new Vector3(-initPos, 0, 0);
            }
            Instantiate(tramp, vect, new Quaternion());    
        }
    }
}
