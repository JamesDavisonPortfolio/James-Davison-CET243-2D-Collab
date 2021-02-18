using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public int damage;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector2 direction = collision.transform.position - gameObject.transform.position;
            collision.GetComponent<EnemyActivation>().TakeDamage(damage, direction);
        }
        Destroy(gameObject);
    }
}
