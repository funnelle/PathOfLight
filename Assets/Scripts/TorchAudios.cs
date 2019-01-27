using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAudios : MonoBehaviour
{
    public AudioClip on;

    public AudioClip off;

    public AudioClip alreadyOn;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySFX(string action)
    {

        if (action == "Turn On")
        {
            source.clip = on;
        }
        else if (action == "Turn Off")
        {
            source.clip = off;
        }
        else if (action == "Already On")
        {
            source.clip = alreadyOn;
        }
        source.Play();
    }
}

