using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CharacterController2D>().GetHeart();
            gameObject.GetComponent<Animator>().SetBool("isTaken", true);
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
