using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudios : MonoBehaviour
{
    public AudioClip takeDamage;

    public AudioClip death;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySFX(string action)
    {

        if (action == "Death")
        {
            source.clip = death;
        }
        else if (action == "Take Damage")
        {
            source.clip = takeDamage;
        }
        source.Play();

    }
}
