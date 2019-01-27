using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour, IDamageable
{
    /* 26 Jan 2019 https://www.youtube.com/watch?v=CHV1ymlw-P8 */

    public NavMeshAgent agent;

    public float detectDist;

    public float attackDelay;

    public float health;

    public GameObject gManagerRef;

    private GameObject attackHitbox;
    
    private List<GameObject> proximityTorches;

    private GameObject playerRef;

    private GameObject hutRef;
    
    private GameObject target;

    private GameObject prevTarg;
    
    private float attackDuration = 0.5f;
    
    private float attackRange = 0.8f;

    private float attackCooldown;


    void Start()
    {
        attackHitbox = transform.Find("Attack Hitbox").gameObject;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        proximityTorches = new List<GameObject>();
        // initial target: Main hut
        hutRef = GameObject.Find("Hut");
        target = hutRef;
        prevTarg = target;
        attackCooldown = Time.time + attackDelay;
        //health = gManagerRef.GetComponent<Game_Manager>().enemySpawnHP;
    }


    void Update()
    {
        TargetSelection();
        MoveTowardsTarget();
        Attack();
    }

    private void TargetSelection()
    {
        if (target.tag != "Player")
        {
            float minTorch = 99f;
            foreach (GameObject torch in proximityTorches)
            {
                if (Vector3.Distance(torch.transform.position, transform.position) <= minTorch)
                {
                    target = torch;
                    minTorch = Vector3.Distance(torch.transform.position, transform.position);
                }
            }
        }
        else if (Vector3.Distance(transform.position, playerRef.transform.position) > detectDist * 1.8)
        {
            target = hutRef;
        }

        if (Vector3.Distance(transform.position, playerRef.transform.position) < detectDist)
        {
            prevTarg = target;
            target = playerRef;
        }
    }

    private void MoveTowardsTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    private void ChangeTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    private void Attack() {
        if (Time.time >= attackCooldown) {
            Ray attackDetection = new Ray(transform.position, target.transform.position - transform.position);
            RaycastHit atkRayHit;
            if (Physics.Raycast(attackDetection, out atkRayHit, attackRange)) {
                Debug.Log(target.tag);
                //attack hitbox
                SpawnHitbox();
                //cooldown
                attackCooldown = Time.time + attackDelay;
                //deal damage
            }
        }
    }

    private void SpawnHitbox () {
        //get hitbox; turn on
        attackHitbox.GetComponent<Collider>().enabled = true;
        //turn off after delay
        StartCoroutine("DespawnHitbox");
    }

    //turn off hitbox here
    private IEnumerator DespawnHitbox() {
        yield return new WaitForSeconds(attackDuration);
        attackHitbox.GetComponent<Collider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Torch")
        {
            proximityTorches.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Torch")
        {
            proximityTorches.Remove(other.gameObject);
        }
    }

    public void TakeDamage() {
        health--;

        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        //how to die
    }
}