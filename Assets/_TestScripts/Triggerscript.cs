using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerscript : MonoBehaviour
{
    Collider m_ObjectCollider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure they have a Collider component)
        m_ObjectCollider = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        m_ObjectCollider.isTrigger = false;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }

    void OnMouseDown()
    {
        //GameObject's Collider is now a trigger Collider when the GameObject is clicked. It now acts as a trigger
        m_ObjectCollider.isTrigger = true;
        //Output to console the GameObject’s trigger state
        Debug.Log("Trigger On : " + m_ObjectCollider.isTrigger);
    }
}
