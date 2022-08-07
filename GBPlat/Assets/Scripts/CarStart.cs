using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStart : MonoBehaviour
{
    [SerializeField] private GameObject car;
    [SerializeField] private AudioLib audioLib;
    private bool done = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!done)
            {
                car.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5000, ForceMode2D.Force);
                audioLib.PlaySound(audioLib.car);
                StartCoroutine(SoundTimer());
            }
            done = true;
        }
    }
    IEnumerator SoundTimer()
    {
        yield return new WaitForSeconds(7f);
        audioLib.StopPlaying();
    }
}
