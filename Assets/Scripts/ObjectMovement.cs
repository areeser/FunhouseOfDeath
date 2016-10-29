using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

    public Vector2 movement = new Vector3(0, 5);
    public float despawnTime = 4.0f;
    public float timer = 0.0f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
        timer += Time.deltaTime;
        if (timer >= despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
