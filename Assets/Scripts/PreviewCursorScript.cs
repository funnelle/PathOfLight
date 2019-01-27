using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCursorScript : MonoBehaviour
{
    void Update()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            Vector3 playerToMouse = floorHit.point;
            playerToMouse.y = 3f;
            transform.position = playerToMouse;
        }
    }
}
