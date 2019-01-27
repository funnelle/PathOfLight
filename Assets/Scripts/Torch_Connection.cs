using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Connection : MonoBehaviour {
    [SerializeField] private float lightIntensity = 15.44f;

    public bool powered = false;
    public Light torchLight;
    public ParticleSystem fire;
    public Game_Manager gm;

    // Start is called before the first frame update
    void Start() {
        torchLight.intensity = 0f;
        if (this.tag == "Torch") {
            fire.Stop();
        }
    }

    // Update is called once per frame
    void Update() {
        //controls light
        if (powered) {
            torchLight.intensity = lightIntensity;
            if (!fire.isPlaying && this.tag == "Torch") {
                fire.Play();
            }
            if (this.tag == "Shrine") {
                gm.manaPerSecond += 1f;
            }

        }
        else {
            torchLight.intensity = 0f;
            if (fire.isPlaying && this.tag == "Torch") {
                fire.Stop();
            }
            if (this.tag == "Shrine") {
                gm.manaPerSecond -= 1f;
            }
        }

    }
}
