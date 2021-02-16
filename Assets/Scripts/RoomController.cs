using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject vCamera;
    public GameObject[] enemies = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vCamera.SetActive(true);
            if(enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].SetActive(true);
                }
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            vCamera.SetActive(false);
            if(enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].SetActive(false);
                }
            }
        }
    }
}
