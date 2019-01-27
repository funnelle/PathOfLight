using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineAudios : MonoBehaviour
{
    public AudioClip connect;

    public AudioClip disconnect;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySFX(string action)
    {
        if (action == "Connect")
        {
            source.clip = connect;
        }
        else if (action == "Disconnect")
        {
            source.clip = disconnect;
        }
        source.Play();
    }
}