using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Connection : MonoBehaviour, IDamageable {
    [SerializeField] private float lightIntensity = 15.44f;

    public bool powered = false;
    public Light torchLight;
    public ParticleSystem fire;
    public Game_Manager gm;

    private bool found = false;

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
            if (gameObject.CompareTag("Shrine") && found == false) {
                Debug.Log("powered");
                found = true;
                gm.shrinesCollected++;
                gm.manaPerSecond += 0.5f;
                gm.maxMana += 1f;
                if (!fire.isPlaying && this.tag == "Torch") {
                    fire.Play();
                }
            }
        }
        else {
            torchLight.intensity = 0f;
            if (gameObject.CompareTag("Shrine") && found == true) {
                Debug.Log("unpowered");
                found = false;
                gm.shrinesCollected--;
                gm.manaPerSecond -= 0.5f;
                gm.maxMana -= 1f;
            }
            if (fire.isPlaying && this.tag == "Torch") {
                fire.Stop();
            }
        }
    }

    public void TakeDamage() {
        powered = false;
    }
}
