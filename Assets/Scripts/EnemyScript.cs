using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    /* 26 Jan 2019 https://www.youtube.com/watch?v=CHV1ymlw-P8 */

    public NavMeshAgent agent;

    public float detectDist;

    private List<GameObject> proximityTorches;

    private GameObject playerRef;

    private GameObject target;

    private GameObject prevTarg;

    void Start() {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        proximityTorches = new List<GameObject>();
        // semi random initial targer (middle of level???)
        target = GameObject.Find("Hut");
        prevTarg = target;
    }
    

    void Update ()
    {
        TargetSelection();
        MoveTowardsTarget();
    }

    private void TargetSelection () {
        if (target.tag != "Player") {
            float minTorch = 99f;
            foreach (GameObject torch in proximityTorches) {
                if (Vector3.Distance(torch.transform.position, transform.position) <= minTorch) {
                    target = torch;
                }
            }
        }

        if (Vector3.Distance(transform.position, playerRef.transform.position) < detectDist) {
            prevTarg = target;
            target = playerRef;
        } else if (Vector3.Distance(transform.position, playerRef.transform.position) > detectDist * 1.2) {
            target = prevTarg;
        }
    }

    private void MoveTowardsTarget() {
        agent.SetDestination(target.transform.position);
    }

    private void ChangeTarget(GameObject newTarget) {
        target = newTarget;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Torch") {
            proximityTorches.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Torch") {
            proximityTorches.Remove(other.gameObject);
        }
    }
}
