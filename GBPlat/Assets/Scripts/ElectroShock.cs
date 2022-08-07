using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroShock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            collision.collider.GetComponent<CharacterController2D>().GetDamage();
        }
    }
}
