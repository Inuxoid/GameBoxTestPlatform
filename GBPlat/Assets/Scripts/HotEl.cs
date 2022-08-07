using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotEl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D EL;
    [SerializeField] private AudioLib audioLib;
    private bool done = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!done)
            {
                StartCoroutine(SoundTimer());
                EL.bodyType = RigidbodyType2D.Dynamic;
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
