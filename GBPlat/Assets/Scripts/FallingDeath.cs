using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject.GetComponent<Collider2D>());
            collision.GetComponent<CharacterController2D>().Death();
        }
    }
}
