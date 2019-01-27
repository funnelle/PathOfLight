using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudios : MonoBehaviour
{
    public AudioClip takeDamage;

    public AudioClip death;

    public AudioObject audioObj;

    public void PlaySFX(string action)
    {
        audioObj = new AudioObject();

        if (action == "Death")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(death);
        }
        else if (action == "Take Damage")
        {
            audioObj.GetComponent<AudioObject>().PlayClip(takeDamage);
        }
    }
}
