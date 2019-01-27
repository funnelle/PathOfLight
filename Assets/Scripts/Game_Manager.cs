﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {
    public List<List<GameObject>> torchLineLists = new List<List<GameObject>>();
    public List<GameObject> torchLine1 = new List<GameObject>();
    /*public List<GameObject> torchLine2 = new List<GameObject>();
    public List<GameObject> torchLine3 = new List<GameObject>();
    public List<GameObject> torchLine4 = new List<GameObject>();
    public List<GameObject> torchLine5 = new List<GameObject>();
    public List<GameObject> torchLine6 = new List<GameObject>();
    public List<GameObject> torchLine7 = new List<GameObject>();
    public List<GameObject> torchLine8 = new List<GameObject>();
    public List<GameObject> torchLine9 = new List<GameObject>();*/

    public float totalMana = 0f;
    public float manaPerSecond = 1.0f;

    private void Start() {
        torchLineLists.Add(torchLine1);
        /*torchLineLists.Add(torchLine2);
        torchLineLists.Add(torchLine3);
        torchLineLists.Add(torchLine4);
        torchLineLists.Add(torchLine5);
        torchLineLists.Add(torchLine6);
        torchLineLists.Add(torchLine7);
        torchLineLists.Add(torchLine8);
        torchLineLists.Add(torchLine9);*/
    }

    private void Update() {
        for (int i = 0; i < torchLineLists.Count; i++) {
            bool connectionLost = false; 
            for (int j = 0; j < torchLineLists[i].Count; j++) {
                if (connectionLost == true) {
                    LineRenderer line = torchLineLists[i][j].GetComponent<LineRenderer>();
                    line.enabled = false;
                }
                if (torchLineLists[i][j].GetComponent<Torch_Connection>().powered == true && 
                torchLineLists[i][j+1].GetComponent<Torch_Connection>().powered == true && 
                    connectionLost == false) {
                    LineRenderer line = torchLineLists[i][j].GetComponent<LineRenderer>();
                    line.enabled = true;
                    line.SetPosition(0, torchLineLists[i][j].transform.position);
                    line.SetPosition(1, torchLineLists[i][j+1].transform.position);
                }
                if (torchLineLists[i][j].GetComponent<Torch_Connection>().powered == false ||
                torchLineLists[i][j+1].GetComponent<Torch_Connection>().powered == false) {
                    connectionLost = true;
                    LineRenderer line = torchLineLists[i][j].GetComponent<LineRenderer>();
                    line.enabled = false;
                }
            }
        }
        StartCoroutine(manaCounter());
    }

    private IEnumerator manaCounter() {
        yield return new WaitForSeconds(1f);
        totalMana += manaPerSecond;
    }
}

