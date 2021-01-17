using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;
using System;

public class FirstAidInterventions : MonoBehaviour
{

    [SerializeField] Examine examine;
    [SerializeField] TextMeshProUGUI[] textsOnInterventionPanel;
    [SerializeField] GameObject finishButton;

    [SerializeField] GameObject finalPanel;

    public bool check;
    public List<Injury> clickedButtons;
    void Start()
    {
        clickedButtons = new List<Injury>();
    }

    void Update()
    {
        if (clickedButtons.Count == 4)
        {
            gameObject.SetActive(false);
            finishButton.SetActive(true);
        }
    }

    public void ShowIntervention()
    {
        gameObject.SetActive(true);

        ChangeIntervention(examine.injuriesForShow);
        
    }

    public void ChangeIntervention(Injury[] injuries)
    {

        for (int i = 0; i < examine.injuriesForShow.Length; i++)
        {
            textsOnInterventionPanel[i].text = injuries[i].Intervention;
        }

    }
    public void AddClickedButton()
    {
        TextMeshProUGUI txt = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>();


        foreach (Injury inj in examine.injuriesForShow)
        {
            if (inj.Intervention == txt.text && clickedButtons.Where(n => n.Intervention == txt.text).FirstOrDefault() == null)
            {
                clickedButtons.Add(inj);
            }
            else if (txt.text == "Call Emergency Number" && clickedButtons.Where(n => n.Intervention == txt.text).FirstOrDefault() == null)
            {
                Injury injury = new Injury() { Intervention = "Call Emergency Number", Importance = 0 };
                clickedButtons.Add(injury);


            }

        }


    }
    public void CheckOrder()
    {
       check = true;
        for(int i = 0; i < clickedButtons.Count; i++)
        {
            if (i != clickedButtons[i].Importance)
            {
                check = false;
                break;
            }
           
        }
        FinishFirstAid();
    }

    private void FinishFirstAid()
    {
        finalPanel.SetActive(true);
        examine.enabled = false;
        gameObject.SetActive(false);
       
    }
}
