using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRingScript : MonoBehaviour
{
    public GameObject spellPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(spellPrefab, transform.position, spellPrefab.transform.rotation);
        }
    }
}
