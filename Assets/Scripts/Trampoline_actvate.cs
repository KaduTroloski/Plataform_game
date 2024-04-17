using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline_actvate : MonoBehaviour
{

    private Animator anim;

    public float JumpForce;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Actvate");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
