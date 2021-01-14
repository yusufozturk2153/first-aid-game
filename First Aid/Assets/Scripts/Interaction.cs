using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

    [SerializeField] float interactionDistance = 1.5f;
    [SerializeField] KeyCode interactKey;
    [SerializeField] UnityEvent interactAction;
    [SerializeField] GameObject instructions;
    [SerializeField] Camera cam;



    MovementAnimations movement; 
    Animator opening;
    Text text;
    RaycastHit raycastHit;
    bool isOpen;
    


    void Start()
    {
        movement = new MovementAnimations();
        text = instructions.GetComponentInChildren<Text>();
        opening = GetComponent<Animator>();
        
    }

    void Update()
    {
        InteractWithObject();
    }

    public void InteractWithObject()
    {
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out raycastHit, interactionDistance) && raycastHit.collider.gameObject.name==gameObject.name)
        {
           
            instructions.SetActive(true);
            text.text=ChangeInstructions(raycastHit.collider.gameObject.tag);

            if (Input.GetKeyDown(interactKey))
              {
                   interactAction.Invoke();
              }
        }
        else 
        {

            //instructions.SetActive(false);
        }

      
    }

    
    public string ChangeInstructions(string tag)
    {

        isOpen = opening.GetBool("isOpen");


        if (movement.isDriving)
        {
           return "Press 'F' For Get Off The Car";
        }

        else if ((tag=="Door"|| tag=="Trunk")&& !isOpen)
        {
            return "Press 'F' For Open";
        }
        else if((tag == "Door" || tag == "Trunk") && isOpen)
        {
            return "Press 'F' For Close";
        }
        else if (tag=="FirstAidKit")
        {
            return "Press 'E' For Take";
        }
        else
        {
            return "Press 'E' For Examine";
        }

        
    }
}
