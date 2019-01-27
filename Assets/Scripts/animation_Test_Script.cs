using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_Test_Script : MonoBehaviour
{
    public Animator animationController;
    int switchValue = 0;
	// Use this for initialization
	void Start ()
    {
        animationController = this.GetComponentInChildren<Animator>();

        animationController.Play("Idle");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            switchValue++;
            AnimationSwitch();
        }
	}

    void AnimationSwitch()
    {
        switch (switchValue)
        {
            case 1:
                Debug.Log("Space pressed");
                animationController.Play("Walk");

                break;
            default:
                animationController.Play("Idle");
                break;
        }
    }
}
