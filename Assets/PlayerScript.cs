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

    private int groundMask;

    private Vector3 moveVals;

    private Rigidbody rbody;

    
    void Start () {
        rbody = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        
    }

    void FixedUpdate () {
        GetInput();

        Move();
        Rotate();
  
    }

    private void GetInput () {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        moveVals.Set(h, 0f, v);

        if (Input.GetMouseButtonDown(0))
        {
            RangeAttack();
        }
    }

    private void Move ()
    {
        moveVals = moveVals.normalized * moveSpeed * Time.deltaTime;
        rbody.MovePosition(transform.position + moveVals);
    }

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
        }
    }

    private void RangeAttack () {
        //get target loc/direction
        Vector3 spawnLoc = transform.position + transform.forward * 0.7f;
        //spawn projectile
        Instantiate(projectile, spawnLoc, transform.rotation);
    }
}
