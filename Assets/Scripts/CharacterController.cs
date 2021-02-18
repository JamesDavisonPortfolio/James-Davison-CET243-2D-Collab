using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float speed;
    public Image[] healthIcons;
    public float knockbackForce;
    public Sprite activeHealth;
    public Sprite damagedHealth;
    public Rigidbody2D rb;
    public Vector2 roomStart;
    private int maxHealth = 4;
    private int health;
    private bool invincible = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        SetHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            health = maxHealth;
            SetHealthBar();
        }
    }

    public void TakeDamage(int damageValue, Vector2 knockbackDirection)
    {

        if (!invincible)
        {
            StartCoroutine("InvincibleTimer");

            health -= damageValue;

            Vector2 knocknackVector;
            if (knockbackDirection.x > 0)
            {
                knocknackVector = new Vector2(1, 0);
            }
            else
            {
                knocknackVector = new Vector2(-1, 0);
            }

            rb.AddForce(knocknackVector * knockbackForce);

            if (health <= 0)
            {
                PlayerDied();
            }
        }
        SetHealthBar();
    }

    public void TakeHazardDamage(int damageValue)
    {
        Debug.Log("player receiving hazard");
        StartCoroutine("InvincibleTimer");

        health -= damageValue;

        if (health <= 0)
        {
            PlayerDied();
        }
        else
        {
            transform.position = roomStart;
        }

        SetHealthBar();
    }
    IEnumerator InvincibleTimer()
    {
        invincible = true;
        yield return new WaitForSeconds(1f);
        invincible = false;
    }
    public void HealthChange(int healthValue)
    {
        health += healthValue;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (healthValue < 0)
        {
            rb.AddForce(transform.right * knockbackForce);
        }
        if (health <= 0)
        {

        }

        SetHealthBar();
    }

    void PlayerDied()
    {

    }

    void SetHealthBar()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            if (health > i)
            {
                healthIcons[i].sprite = activeHealth;
            }
            else
            {
                healthIcons[i].sprite = damagedHealth;
            }
        }
    }
}
