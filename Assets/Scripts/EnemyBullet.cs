using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;
    public float speed;
    public int damage;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        direction = (player.transform.position -  transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 playerDirection;
            playerDirection = player.transform.position - transform.position;
            player.GetComponent<CharacterController>().TakeDamage(damage, playerDirection);
        }
        Destroy(gameObject);
    }
}
