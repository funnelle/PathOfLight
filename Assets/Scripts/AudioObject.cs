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
        Debug.Log("am i still running??");
    }

    private IEnumerator DestroyObj(AudioClip clip) {
        yield return new WaitForSeconds(clip.length);
        if (gameObject.activeInHierarchy)
            Destroy(this.gameObject);
    }
}
