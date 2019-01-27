using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour {
    public List<List<GameObject>> torchLineLists = new List<List<GameObject>>();
    public List<GameObject> torchLine1 = new List<GameObject>();
    public List<GameObject> torchLine2 = new List<GameObject>();
    public List<GameObject> torchLine3 = new List<GameObject>();
    public List<GameObject> torchLine4 = new List<GameObject>();
    public List<GameObject> torchLine5 = new List<GameObject>();
    public List<GameObject> torchLine6 = new List<GameObject>();
    public List<GameObject> torchLine7 = new List<GameObject>();
    public List<GameObject> torchLine8 = new List<GameObject>();
    public List<GameObject> torchLine9 = new List<GameObject>();

    public float totalMana = 0f;
    public float maxMana = 3f;
    public float manaPerSecond = 1f;
    public float shrinesCollected = 0f;

    public float enemySpawnHP = 3f;

    public Text totalManaText;
    public Text shrinesLeftText;
    public Text healthText;

    private bool onCollectingMana = false;
    private bool onIncreasingHP = false;

    private void Start() {
        torchLineLists.Add(torchLine1);
        torchLineLists.Add(torchLine2);
        torchLineLists.Add(torchLine3);
        torchLineLists.Add(torchLine4);
        torchLineLists.Add(torchLine5);
        torchLineLists.Add(torchLine6);
        torchLineLists.Add(torchLine7);
        torchLineLists.Add(torchLine8);
        torchLineLists.Add(torchLine9);
    }

    private void Update() {
        //enemy HP timer
        if (onIncreasingHP == false) {
            onIncreasingHP = true;
            StartCoroutine(enemyHPTimer());
        }

        //Mana gui
        if (totalMana < maxMana && onCollectingMana == false) {
            onCollectingMana = true;
            StartCoroutine(manaCounter());
        }

        //Torch Lines
        for (int i = 0; i < torchLineLists.Count; i++) {
            bool connectionLost = false; 
            for (int j = 0; j < torchLineLists[i].Count; j++) {
                if (connectionLost == true) {
                    LineRenderer line = torchLineLists[i][j].GetComponent<LineRenderer>();
                    line.enabled = false;
                }
                if (torchLineLists[i][j].GetComponent<Torch_Connection>().powered == true &&
                torchLineLists[i][j+1].gameObject.CompareTag("Shrine")) {
                    torchLineLists[i][j + 1].GetComponent<Torch_Connection>().powered = true;
                    LineRenderer line = torchLineLists[i][j].GetComponent<LineRenderer>();
                    line.enabled = true;
                    line.SetPosition(0, torchLineLists[i][j].transform.position);
                    line.SetPosition(1, torchLineLists[i][j + 1].transform.position);
                }
                if (torchLineLists[i][j].GetComponent<Torch_Connection>().powered == true &&
                torchLineLists[i][j + 1].gameObject.CompareTag("Shrine") && connectionLost == true) {
                    torchLineLists[i][j + 1].GetComponent<Torch_Connection>().powered = false;
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

        //shrine gui
        shrinesLeftText.text = "Shrines Found: " + shrinesCollected.ToString() + "/9";

    }

    private IEnumerator manaCounter() {
        totalMana += manaPerSecond;
        totalManaText.text = "Total Mana: " + totalMana.ToString();
        yield return new WaitForSeconds(1f);
        onCollectingMana = false;
    }

    private IEnumerator enemyHPTimer() {
        yield return new WaitForSeconds(60f);
        enemySpawnHP += 1f;
        onIncreasingHP = false;
    }
}

