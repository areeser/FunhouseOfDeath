using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public float transitionSpeed = 1.0f;
    public float changable = 5.0f;
    public Camera cam;
    public Vector3 playerPos;
    public int points = 0;
    public int timer = 0;
    public bool canGoBack = true;
    public bool canCreateWall = false;
    public bool canChange = true;
    public Vector3 point0 = new Vector3(20.3f, 9.9f, -22);
    public Vector3 point1 = new Vector3(64.1f, 18.5f, -13);
    public Vector3 point2 = new Vector3(110.1f, 26.5f,-23);
   
    // Use this for initialization
    void Start () {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = cam.WorldToScreenPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        if (playerPos.x > cam.pixelWidth - 1) {
            if (canChange) {
                points++;
                if (!canGoBack) {
                    canCreateWall = true;
                }
            }
            canChange = false;
        }
        else if (playerPos.x < 1 && canGoBack) {
            if (canChange) {
                points--;
            }
            canChange = false;
        }
        else {
            canChange = true;
        }
        if (points == 0) {
            gameObject.transform.Translate((point0 - gameObject.transform.position) * Time.deltaTime * transitionSpeed);
            if ((point0 - gameObject.transform.position).magnitude < changable) {
                canChange = true;
            }
        }
        if (points == 1) {
            gameObject.transform.Translate((point1 - gameObject.transform.position) * Time.deltaTime * transitionSpeed);
            if ((point1 - gameObject.transform.position).magnitude < changable)
            {
                canChange = true;
            }
        }
        if (points == 2) {
            gameObject.transform.Translate((point2 - gameObject.transform.position) * Time.deltaTime * transitionSpeed);
            if ((point2 - gameObject.transform.position).magnitude < changable)
            {
                canChange = true;
            }
        }
    }
}
