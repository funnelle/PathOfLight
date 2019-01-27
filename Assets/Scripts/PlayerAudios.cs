using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudios : MonoBehaviour
{
    public AudioClip takeDamage;

    public AudioClip attack;

    public AudioSource source;

    public void PlaySFX(string action)
    {
        if (action == "Attack")
        {
            //audioObj.GetComponent<AudioObject>().PlayClip(attack);
            source.clip = attack;

        }
        else if (action == "Take Damage") {
            //audioObj.GetComponent<AudioObject>().PlayClip(takeDamage);
            source.clip = takeDamage;
        }

        source.Play();
    }
}
