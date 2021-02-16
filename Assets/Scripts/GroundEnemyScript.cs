using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyScript : MonoBehaviour
{
    public bool goingRight = true;
    public float speed;
    public GameObject player;
    private int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (goingRight)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Patrol Boundry")
        {
            Debug.Log("Boundry Hit");
            if (goingRight)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
        }

        if (collision.tag == "Player")
        {
            Debug.Log("Player Hit");
            Vector2 playerDirection;
            playerDirection = player.transform.position - transform.position;
            player.GetComponent<CharacterController>().TakeDamage(damage, playerDirection);
        }
    }
}

