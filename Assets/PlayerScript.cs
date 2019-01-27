using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{ 
    /* 
    25-Jan-2019 https://unity3d.com/learn/tutorials/projects/survival-shooter/player-character?playlist=17144
    */

    public float moveSpeed;

    public Transform projectile;

    public Transform torchObj;

    public GameObject torchPreview;

    private float defaultMoveSpeed;

    private float buildMoveSpeed;

    private int groundMask;

    private Vector3 moveVals;

    private Rigidbody rbody;

    private bool isBuilding;

    private Vector3 mousePos;

    
    void Start () {
        rbody = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        isBuilding = false;
        defaultMoveSpeed = moveSpeed;
        buildMoveSpeed = moveSpeed * 0.6f;
        mousePos = Vector3.zero;
    }

    void FixedUpdate () {
        GetInput();

        Move();
        Rotate();
  
    }

    // Handles all input regarding this object
    private void GetInput () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveVals.Set(h, 0f, v);

        if (Input.GetMouseButtonDown(0))
        {
            if (!isBuilding)
                RangeAttack();
            else
                BuildTorch();
        }

        if (Input.GetMouseButtonDown(1)) {
            BuildMode();
        }
    }

    // Move player based on user input
    private void Move ()
    {
        moveVals = moveVals.normalized * moveSpeed * Time.deltaTime;
        rbody.MovePosition(transform.position + moveVals);
    }

    // Turn object such that it is facing mouse location relative to ground
    private void Rotate () {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, Mathf.Infinity, groundMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rbody.MoveRotation(newRotation);

            // get mouse position for other referencing
            mousePos = playerToMouse;
        }
    }

    // Spawn projectile object in the direction the player is facing
    private void RangeAttack () {
        Vector3 spawnLoc = transform.position + transform.forward * 0.7f;
        Instantiate(projectile, spawnLoc, transform.rotation);
    }

    private void BuildMode() {
        if (isBuilding)
        {
            isBuilding = false;
            moveSpeed = defaultMoveSpeed;
            //cursor reset
            torchPreview.GetComponent<MeshRenderer>().enabled = false;
        }
        else {
            isBuilding = true;
            moveSpeed = buildMoveSpeed;
            //change cursor to preview build
            torchPreview.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void BuildTorch() {
        Instantiate(torchObj, torchPreview.transform.position, Quaternion.identity);
        isBuilding = false;
        torchPreview.GetComponent<MeshRenderer>().enabled = false;
        moveSpeed = defaultMoveSpeed;
    }
}
