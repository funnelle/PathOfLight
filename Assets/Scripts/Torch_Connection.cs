using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Connection : MonoBehaviour {
    [SerializeField] private float lightIntensity = 15.44f;

    public bool powered = false;
    public Light torchLight;

    // Start is called before the first frame update
    void Start() {
        torchLight.intensity = 0f;
    }

    // Update is called once per frame
    void Update() {
        //controls light
        if (powered) {
            torchLight.intensity = lightIntensity;
        }
        else {
            torchLight.intensity = 0f;
        }

    }
}
