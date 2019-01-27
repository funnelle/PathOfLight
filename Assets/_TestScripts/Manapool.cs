using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Manapool : MonoBehaviour
{
    // radius detection 
    // bool of power torches 
    public GameObject pools;
    public string[] threeTorches;

    public int maxRange;
    public int minRange;

    public int torchesCount;
    public int ManaCount;

    public Camera main;
    public float range;

    private Vector3 Pooltransform;

    bool powerTorches = true;

    public List<Manapool> AllTorches;

    void Start()
    {
        pools = GameObject.FindWithTag("Player");
        torchesCount = 0;
    }

    void Update()
    {

        if ((Vector3.Distance(transform.position, pools.transform.position) < maxRange))
        {
            Debug.Log("You are in range");
            //ManaWithTorchesLit();
        }

        if ((Vector3.Distance(transform.position, pools.transform.position) > minRange))
        {
            Debug.Log("You are not in range");
        }

        if (Input.GetMouseButtonDown(0))
        {
            FindTorch();
        }
    }
    // if all three torches are lit, then give the player 1 mana
    public void ManaWithTorchesLit()
    {
        if (torchesCount == 3)
        {
            ManaCount += 1;
            Debug.Log("You earned a mana");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        powerTorches = true;
        if (collision.gameObject.name == "Player")
        {
            //torchesCount ++;
            Debug.Log("You lit a torch");
            Debug.Log(torchesCount);
        }
    }

    void OnCollisionExit(Collision other)
    {
       /// torchesCount = 0; 
    }

    public void FindTorch()
    {
        RaycastHit hit;
        if (Physics.Raycast(main.transform.position, main.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("Torch"))
            {
                GameObject pools = hit.transform.GetComponent<GameObject>();
                Debug.Log(pools);
                Debug.Log(torchesCount); 
            }
        }
    }

    //IEnumerator ToTorch()
    //{
    //    yield return new WaitForSeconds(2f);

    //    for (int i = 0; i < torchesCount; i++)
    //    {
           
    //    }
    //}
}