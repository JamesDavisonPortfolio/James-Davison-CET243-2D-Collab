using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    public GameObject characterRing;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreLayerCollision(11, 13);
            characterRing.SetActive(true);
            Destroy(gameObject);
        }
    }

}
