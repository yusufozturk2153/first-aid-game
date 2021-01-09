using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstAidInterventions : MonoBehaviour
{
    [SerializeField] GameObject examine;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowExamine()
    {
        examine.SetActive(true);
    }
}
