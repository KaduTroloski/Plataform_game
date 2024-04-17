using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallungPlataform : MonoBehaviour
{

    public float Timer;

    private TargetJoint2D joint;
    private BoxCollider2D box;


    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<TargetJoint2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Falling", Timer);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        joint.enabled = false;
        box.isTrigger = true;
    }
}

