using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Unlock : MonoBehaviour
{
    private BoxCollider2D BoxColl;
    private Renderer Rend;
    public Player_Controller playcon;
    public bool locked = true;

    // Start is called before the first frame update
    void Start()
    {
        BoxColl = GetComponent<BoxCollider2D>();
        Rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //lock and unlock
        //activate only when 926 is alaive
        if (playcon.gameOver == false && playcon.isOnGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (locked == false)
                {
                    locked = true;
                }
                else
                {
                    locked = false;
                }
            }
        }
        if (locked == true)
        {
            Rend.enabled = true;
            BoxColl.enabled = true;
            
        }
        else
        {
            Rend.enabled = false;
            BoxColl.enabled = false;
        }
    }
}
