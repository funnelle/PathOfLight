using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || other.CompareTag("Torch")) {
            other.gameObject.GetComponent<IDamageable>().TakeDamage();
        }
    }
}
