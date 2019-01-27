using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudios : MonoBehaviour
{
    public AudioClip takeDamage;

    public AudioClip attack;

    public AudioObject audioObj;

    public void PlaySFX(string action)
    {
        audioObj = new AudioObject();
        Instantiate(audioObj, gameObject.transform);

        if (action == "Attack")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(attack);
        }
        else if (action == "Take Damage") {
            audioObj.GetComponent<AudioObject>().PlayClip(takeDamage);
        }
    }
}
