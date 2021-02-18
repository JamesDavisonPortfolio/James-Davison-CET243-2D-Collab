using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivation : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public float knockBackForce;
    public GameObject[] possibleDrops;
    private Rigidbody2D rb;

    public Vector3 startPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        health = maxHealth;
        transform.position = startPosition;
    }

    private void OnDisable()
    {

    }

    public void TakeDamage(int damageValue, Vector2 knockbackDirection)
    {

        health -= damageValue;

        rb.AddForce(knockbackDirection * knockBackForce);

        if (health <= 0)
        {
            
            
            gameObject.SetActive(false);

        }
    }
}
