using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource emisor;
    public AudioClip musica;
    public float volumen = 1;

    private void OnTriggerEnter(Collider other)
    {
        emisor.PlayOneShot(musica, volumen);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    emisor.(musica, volumen);
    //}
}
