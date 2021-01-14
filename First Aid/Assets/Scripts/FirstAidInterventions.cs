using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstAidInterventions : MonoBehaviour
{
 
    [SerializeField] GameObject intervention;
   

    Button[] buttonsOnInterventionPanel;
    void Start()
    {
        buttonsOnInterventionPanel = intervention.GetComponentsInChildren<Button>();
    }

    void Update()
    {
        
    }

  
}
