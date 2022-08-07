using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    [SerializeField] private AudioLib audioLib;
    private bool done = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!done)
            {
                StartCoroutine(SoundTimer());
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Destroy(gameObject.GetComponent<Collider2D>());
                done = true;
            }
        }
    }

    IEnumerator SoundTimer()
    {
        audioLib.PlaySound(audioLib.falling);
        yield return new WaitForSeconds(3f);
        audioLib.StopPlaying(); 
    }
}
