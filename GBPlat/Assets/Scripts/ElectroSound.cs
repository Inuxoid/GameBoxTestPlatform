using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroSound : MonoBehaviour
{
    [SerializeField] private AudioLib audioLib;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            audioLib.PlaySound(audioLib.electro);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            audioLib.StopPlaying();
    }
}
