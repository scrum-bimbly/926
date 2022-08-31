using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D Rigid;
    private SpriteRenderer Render;
    public Animator anim;
    public int contactCount;
    public float horizontalInput;
    public float verticalInput;
    public float jumpForce = 13;
    public float speed = 20;
    public float gravityScale = 1;
    public bool isOnGround = true;
    public bool levelOver = false;
    public bool gameOver = false;
    public bool playing = false;
    private float level = 0;
    public Teleportal port1;
    public Teleportal port2;

    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        Rigid = GetComponent<Rigidbody2D>();
        Render = GetComponent<SpriteRenderer>();
        anim = gameObject.GetComponent<Animator>();
        Rigid.gravityScale = 2;
        if (level != SceneManager.GetActiveScene().buildIndex)
        {
            SceneManager.LoadScene("level_Wall_Crawler");
            level = 0;
            //this is so it wont repeatedly load the level
        }
    }

    private void Update()
    {
        //only if 926 isn't dead
        if (gameOver == false)
        {
            //player movement
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //play the walk cycle
                Render.flipX = false;
                anim.Play("walk");
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //play the walk cycle
                Render.flipX = true;
                anim.Play("walk");
            }
            else
            {
                //stop
                anim.Play("idle");
            }
            //gravity flip
            //can only flip once after touching the ground
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                //flip the number
                Rigid.gravityScale *= -1 ;
                isOnGround = false;
                //flip the sprite
                if (Rigid.gravityScale == 2)
                {
                    Render.flipY = false;
                }
                else if (Rigid.gravityScale == -2)
                {
                    Render.flipY = true;
                }
            }
        }
        else if (gameOver == true)
        {
            //can't move if your dead
            anim.Play("idle");
        }
        //press r to "r"estart
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            gameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //touch goal, win
        if (collision2D.gameObject.CompareTag("finish"))
        {
            levelOver = true;
            Debug.Log("Level Complete");
            //play the next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            level =+ 1; 
        }
        //touch danger, die
        if (collision2D.gameObject.CompareTag("danger"))
        {
            gameOver = true;
            Debug.Log("oops. death (press R to restart)");
        }
        if (collision2D.gameObject.CompareTag("ground"))
        {
            isOnGround = true;
        }
        if (collision2D.gameObject.CompareTag("portal 1"))
        {
            //transform.Translate();
        }
    }
}