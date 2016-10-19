using UnityEngine;
using System.Collections;
using System;

public class PlayerAnimation : MonoBehaviour {
    //	<Sprite Variables>
    private Sprite[] playerAnimation = new Sprite[8];
    private int playerSpriteAnimationPos = 0;
    private int minSprite, maxSprite, prevMinSprite, prevMaxSprite;
    public float delay = 0.1f;
    private float timer = 0f;
    private bool playerSpriteLoop = true;
    public GameObject playerSprite;
    //	</Sprite Variables>

    // Use this for initialization
    void Start () {
        //Walking
        playerAnimation[0] = Resources.Load<Sprite>("Slime2");
        playerAnimation[1] = Resources.Load<Sprite>("Slime3");
        playerAnimation[2] = Resources.Load<Sprite>("Slime2");
        playerAnimation[3] = Resources.Load<Sprite>("Slime1");
        //Jumping
        playerAnimation[4] = Resources.Load<Sprite>("Slime4");
        playerAnimation[5] = Resources.Load<Sprite>("Slime5");
        playerAnimation[6] = Resources.Load<Sprite>("Slime6");
        playerAnimation[7] = Resources.Load<Sprite>("Slime7");

        playerSprite = GameObject.FindGameObjectWithTag("PlayerSprite");
        playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite = playerAnimation[0];
        minSprite = 0;
        maxSprite = playerAnimation.Length - 1;
    }

    void UpdateSpriteAnimation(string command)
    {
        char[] delims1 = { '|' };
        char[] delims2 = { ' ', ',' };
        string[] commandList = command.Split(delims1);
        for (int i = 0; i < commandList.Length; i++)
        {
            command = commandList[i];
            if (command == "INCREMENT")
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite =
                        playerAnimation[playerSpriteAnimationPos++];
                    timer = delay;
                    if (playerSpriteAnimationPos > maxSprite)
                        if (playerSpriteLoop)
                            playerSpriteAnimationPos = minSprite;
                        else
                            playerSpriteAnimationPos = maxSprite;

                    if (minSprite != prevMinSprite || maxSprite != prevMaxSprite)
                    {
                        playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite =
                            playerAnimation[0];
                        playerSpriteAnimationPos = minSprite;
                        timer = 0;
                    }
                    prevMinSprite = minSprite;
                    prevMaxSprite = maxSprite;
                }
            }
            else if (command == "RESET")
            {
                playerSprite.gameObject.GetComponent<SpriteRenderer>().sprite =
                        playerAnimation[0];
                playerSpriteAnimationPos = minSprite;
                timer = 0;
            }
            else if (command.Split(delims2)[0] == "RANGE")
            {
                minSprite = Convert.ToInt32(command.Split(delims2)[1]);
                maxSprite = Convert.ToInt32(command.Split(delims2)[2]);
            }
            else if (command.Split(delims2)[0] == "DELAY")
            {
                delay = float.Parse(command.Split(delims2)[1]);
            }
            else if (command == "LOOP")
            {
                playerSpriteLoop = true;
            }
            else if (command == "NOLOOP")
            {
                playerSpriteLoop = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        bool touchingGround = gameObject.GetComponent<PlayerMovement>().touchingGround;
        if (Input.GetKey(KeyCode.D) && touchingGround)
        {
            UpdateSpriteAnimation("RANGE 0,3|DELAY 0.1|LOOP|INCREMENT");
        }
        else if (Input.GetKey(KeyCode.A) && touchingGround)
        {
            UpdateSpriteAnimation("RANGE 0,3|DELAY 0.1|LOOP|INCREMENT");
        }
        else
        {
            UpdateSpriteAnimation("RESET");
        }
        if (!(touchingGround))
        {
            UpdateSpriteAnimation("RANGE 4,7|DELAY 0.025|NOLOOP|INCREMENT");
        }
    }
}
