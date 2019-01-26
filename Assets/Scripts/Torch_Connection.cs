using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Connection : MonoBehaviour {
    [SerializeField] private float detectionRange = 10f;

    private SphereCollider torchDetectionArea;
    private List<Collider> torches = new List<Collider>();

    public bool powered = false;

    // Start is called before the first frame update
    void Start() {
        torchDetectionArea = GetComponent<SphereCollider>();
        torchDetectionArea.radius = detectionRange;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(torches.Count);
        for (int i = 0; i < torches.Count; i++) {
            //Debug.Log(torches[i]);
            if(torches[i].GetComponent<Torch_Connection>().powered == true) {
                powered = true;
            }
            else {
                powered = false;
            }
        }
        if (torches.Count == 0) {
            powered = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Torch")) {
            if (!torches.Contains(other)) {
                torches.Add(other);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Torch")) {
            if (torches.Contains(other)) {
                torches.Remove(other);
            }
        }
    }

}
