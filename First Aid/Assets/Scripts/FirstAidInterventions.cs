using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstAidInterventions : MonoBehaviour
{
    [SerializeField] GameObject examine;
    [SerializeField] GameObject intervention;
    [SerializeField] TextMeshProUGUI[] textsOnExaminePanel;

    Button[] buttonsOnInterventionPanel;
    void Start()
    {
        buttonsOnInterventionPanel = intervention.GetComponentsInChildren<Button>();
    }

    void Update()
    {
        
    }

    public void ShowExamine()
    {
        examine.SetActive(true);
        ChangeTextsOnExamine();
    }

    public void ChangeTextsOnExamine()
    {
        string[] texts = new string[] { "The heart beat stopped", "Bleeding in the left arm", "Broken left foot" };

        for(int i=0; i< textsOnExaminePanel.Length; i++)
        {
            textsOnExaminePanel[i].text = texts[i];
        }
    
    }
}
