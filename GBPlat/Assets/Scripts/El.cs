using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class El : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController2D>().GetDamage();
        }
        else if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
