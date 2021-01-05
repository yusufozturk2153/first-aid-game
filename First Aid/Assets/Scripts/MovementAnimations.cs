using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimations : MonoBehaviour
{
    Animator animator;


    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] float delay;
    public bool isDriving;
    
    void Start()
    {
        animator=GetComponent<Animator>();
        isDriving = true;
        delay = 4f;
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkOrRun();
        GetOffTheCar();

    }

    private void FixedUpdate()
    {
        if (!isDriving)
        {
            Invoke("ChangeCameraPosition", delay);
            
            
        }
    }


    //Control walking and running animation

    private void WalkOrRun()
    {
        //TODO create running controller

        if (Input.GetKey("w"))
        {
           
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void GetOffTheCar()
    {
        if (isDriving)
        {
            if (Input.GetKey("f"))
            {
                animator.SetBool("isWalking", true);
                isDriving = false;
            }
        }
        

    }
    void ChangeCameraPosition()
    {
        firstPersonCamera.transform.localPosition = new Vector3(0f, 3.4f, 0.2f);
        GetComponent<CharacterController>().enabled = true;
    }
}
