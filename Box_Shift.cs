using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Shift : MonoBehaviour
{ 
    private Rigidbody2D Rigid;
    private ConstantForce2D Force;
    public int gravity = 0;
    public Player_Controller playcon;
    public bool isleft = true;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.gravityScale = gravity;
        Force = GetComponent<ConstantForce2D>();
        float gravityForceAmount = Rigid.mass * Physics2D.gravity.magnitude;
        Force.force = new Vector2(-gravityForceAmount, 0);
    }

// Update is called once per frame
void Update()
    {
        //gravity shift
        //activate only when 926 is alaive
        if (playcon.gameOver == false && playcon.isOnGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //reverse the number
                Force.force *= -1;
                //flip the arrow to point the other way
                transform.localRotation *= Quaternion.Euler(0, 0, 180);
            }
        }
    }
}
