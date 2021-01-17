using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] FirstAidInterventions intervention;
    [SerializeField] Examine examine;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] Text[] correctTexts;
    [SerializeField] Text[] choiceTexts;
    [SerializeField] Image[] images;
    [SerializeField] Sprite cross;
    [SerializeField] Sprite correct;



    int i ;
    void Start()
    {
        
        ChangeTitle(intervention.check);
        CorrectOrder();
        Choices();
     
    }

  
    void Update()
    {
        
    }

    public void ChangeTitle(bool check)
    {
        if (check)
        {
            title.text = "Successful";
            title.faceColor = Color.green;
        }
        else
        {
            title.text = "Failed";
            title.faceColor = Color.red;
        }
    }
    public void CorrectOrder()
    {
       i = 0;
        correctTexts[i].text = "Call Emergency Number";
        for (i = 0; i < examine.injuriesForShow.Length; i++)
        {
            correctTexts[i+1].text = examine.injuriesForShow[i].Intervention;
        }
        
    }
    public void Choices()
    {
        i = 0;
        foreach (Injury injury in intervention.clickedButtons)
        {
            choiceTexts[i].text = injury.Intervention;
            i++;
        }
        ChangeColorOfChoices();
    }
    public void ChangeColorOfChoices()
    {
        i = 0;
        foreach(Text txt in choiceTexts)
        {
            if (txt.text == correctTexts[i].text)
            {
                txt.color = Color.green;
                images[i].sprite = correct;

            }
            else
            {
                txt.color=Color.red;
                images[i].sprite = cross;
               
            }
            i++;
        }
    }
}
