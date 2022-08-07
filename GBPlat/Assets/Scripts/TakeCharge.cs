using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCharge : MonoBehaviour
{
    [SerializeField] private AudioLib audioLib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioLib.PlayOnce(audioLib.charge);
            collision.GetComponent<CharacterController2D>().AddScore();
            gameObject.GetComponent<Animator>().SetBool("isTaken", true);
            Destroy(gameObject.GetComponent<Collider2D>());
        }
    }
}
