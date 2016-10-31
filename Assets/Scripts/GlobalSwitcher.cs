using UnityEngine;
using System.Collections;

public class GlobalSwitcher : MonoBehaviour
{
    //Toggles visibility and colliders of all objects tagged "Blinker" or "DeathBlinker"
    //All toggle on and off at the same time


    public float timeCounter;
    public bool isActive = true;
    public int secondDelay = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter = Time.time % (2 * secondDelay);
        if (timeCounter <= secondDelay)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("DeathBlinker").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("DeathBlinker")[i].GetComponent<Renderer>().enabled = true;
                GameObject.FindGameObjectsWithTag("DeathBlinker")[i].GetComponent<BoxCollider2D>().enabled = true;
            }
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Blinker").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Blinker")[i].GetComponent<Renderer>().enabled = true;
                GameObject.FindGameObjectsWithTag("Blinker")[i].GetComponent<BoxCollider2D>().enabled = true;
            }

            isActive = true;
        }
        if (timeCounter > secondDelay)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("DeathBlinker").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("DeathBlinker")[i].GetComponent<Renderer>().enabled = false;
                GameObject.FindGameObjectsWithTag("DeathBlinker")[i].GetComponent<BoxCollider2D>().enabled = false;
            }
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Blinker").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("Blinker")[i].GetComponent<Renderer>().enabled = false;
                GameObject.FindGameObjectsWithTag("Blinker")[i].GetComponent<BoxCollider2D>().enabled = false;
            }

            isActive = false;
        }

    }
}
