using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreMoviment : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    public bool DoubleJump;
    public int CountDeath;


    private Rigidbody2D rigid;
    private Animator anima;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePLayer();
        JumpPLayer();
    }

    void MovePLayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anima.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            anima.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if (Input.GetAxis("Horizontal") == 0f)
        {
            anima.SetBool("walk", false);
        }
    }

    void JumpPLayer()
    {
        if(Input.GetButtonDown("Jump"))
            if (!IsJumping)
            {
                rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DoubleJump = true;
                anima.SetBool("jump", true);
            }
            else
            {
                if(DoubleJump)
                {
                    rigid.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DoubleJump = false;
                }
            }
        
    }

    void OnCollisionEnter2D(Collision2D collission)
    {
        if(collission.gameObject.layer == 6)
        {
            IsJumping = false;
            anima.SetBool("jump", false);
        }

        if (collission.gameObject.tag == "Lava")
        {
            GameController.export.ShowGameOver();
            Destroy(gameObject);
            GameController.export.UpdateDeaths(CountDeath);
        }

        if (collission.gameObject.tag == "saw")
        {
            GameController.export.ShowGameOver(); 
            Destroy(gameObject);
            GameController.export.UpdateDeaths(CountDeath);
        }
    }

    void OnCollisionExit2D(Collision2D collission)
    {
        if (collission.gameObject.layer == 6)
        {
            IsJumping = true;
        }
    }
}

