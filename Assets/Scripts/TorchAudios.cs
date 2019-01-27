using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAudios : MonoBehaviour
{
    public AudioClip on;

    public AudioClip off;

    public AudioClip alreadyOn;

    public AudioObject audioObj;

    public void PlaySFX(string action)
    {
        audioObj = new AudioObject();

        if (action == "Turn On")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(on);
        }
        else if (action == "Turn Off")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(off);
        }
        else if (action == "Already On")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(alreadyOn);
        }
    }
}

