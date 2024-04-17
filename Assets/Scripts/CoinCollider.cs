using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D box;

    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") 
        {
            sr.enabled = false;
            box.enabled = false;
            collected.SetActive(true);

            GameController.export.FullScore += Score;
            

            Destroy(gameObject, 0.3f);

            GameController.export.UpdateText();
        }
    }
}
