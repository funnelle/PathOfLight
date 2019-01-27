using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float movementSpeed;

    public float timeLimit = 2.0f;

    private float killTime;

    void Start() {
        killTime = Time.time + timeLimit;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;

        if (Time.time > killTime) {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            //Deal damage
            IDamageable targ = collision.gameObject.GetComponent<IDamageable>();
            if (targ != null) {
                targ.TakeDamage();
            }
        }
        DestroyProjectile();
    }
}
