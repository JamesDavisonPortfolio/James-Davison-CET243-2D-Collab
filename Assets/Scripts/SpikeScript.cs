using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public GameObject player;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("spike detecting collision");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("spike detecting player");
            player.GetComponent<CharacterController>().TakeHazardDamage(damage);
        }
    }
}
