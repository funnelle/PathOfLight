using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip newClip) {
        source.clip = newClip;
        source.Play();

        StartCoroutine("DestroyObj", newClip);
    }

    private IEnumerator DestroyObj(AudioClip clip) {
        yield return new WaitForSeconds(clip.length);
        Destroy(this.gameObject);
    }
}
