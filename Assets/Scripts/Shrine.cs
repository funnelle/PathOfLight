using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrine : MonoBehaviour {
    [SerializeField] private float lightIntensity = 15.44f;

    public bool powered = false;
    public Light shrineLight;
    public Game_Manager gm;

    // Start is called before the first frame update
    void Start() {
        shrineLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update() {
        //controls light
        if (powered) {
            shrineLight.intensity = lightIntensity;
            gm.manaPerSecond += 1f;
        }
        else {
            shrineLight.intensity = 0f;
            gm.manaPerSecond -= 1f;
        }
    }
}
