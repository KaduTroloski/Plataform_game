using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SawMoviment : MonoBehaviour
{
    public float speed;
    public float MoveTime;

    private bool dirRight = true;
    private float timer;
   
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= MoveTime)
        {
            dirRight = !dirRight;
            timer = 0;
        }
    }
}
