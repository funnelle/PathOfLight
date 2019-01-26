using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manapool : MonoBehaviour
{
    // radius detection 
    // bool of power torches 
    public GameObject pools;

    public int maxRange;
    public int minRange;

    public int torchesCount;
    public int ManaCount;

    private Vector3 Pooltransform;


    void Start()
    {
        pools = GameObject.FindWithTag("Player");
    }

    void Update()
    {

        if ((Vector3.Distance(transform.position, pools.transform.position) < maxRange))
        {
            Debug.Log("You are in range");
            ManaWithTorchesLit();
        }

        if ((Vector3.Distance(transform.position, pools.transform.position) > minRange))
        {

            Debug.Log("You are not in range");
        }
    }
    // if all three torches are lit, then give the player 1 mana
    public void ManaWithTorchesLit()
    {
        if (torchesCount >= 3)
        {
            ManaCount += 1;
            Debug.Log("You earned a mana");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ManaTorch")
        {
            torchesCount += 1;
            Debug.Log("You lit a torch");
        }
    }

    void OnCollisionExit(Collision other)
    {
        //if (other.tag == "Player")
        //{
        //    poolTarget = null;
        //    print("You are out of range");
        //}
    }
}
