using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineAudios : MonoBehaviour
{
    public AudioClip connect;

    public AudioClip disconnect;

    public AudioObject audioObj;

    public void PlaySFX(string action)
    {
        audioObj = new AudioObject();
        Instantiate(audioObj, gameObject.transform);

        if (action == "Connect")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(connect);
        }
        else if (action == "Disconnect")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(disconnect);
        }
    }
}