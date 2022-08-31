using UnityEngine;
using UnityEngine.SceneManagement;

public class Box_Flip : MonoBehaviour
{
    private Rigidbody2D Rigid; 
    public int gravity = 2; 
    public Player_Controller playcon;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Rigid.gravityScale = gravity;
    }

    private void Update()
    {
        //gravity flip
        //activate only when 926 is alaive
        if (playcon.gameOver == false && playcon.isOnGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //spin't
                Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                //reverse the number
                Rigid.gravityScale *= -1;
                //flip the arrow to point the other way
                transform.localRotation *= Quaternion.Euler(0, 0, 180);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            //completely stop when 926 touches it
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else if (collision2D.gameObject.CompareTag("ground"))
        {
            //completely stop when walkable ground touches it
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}