using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Examine : MonoBehaviour
{
    [SerializeField] GameObject examine;
    [SerializeField] GameObject intervention;
    [SerializeField] TextMeshProUGUI[] textsOnExaminePanel;
    [SerializeField] TextMeshProUGUI[] textsOnInterventionPanel;
    [SerializeField] Sprite[] images;
    [SerializeField] Image examineImage;
    

    string[] textsForExamine = new string[] { "The heart beat stopped", "Bleeding in the left arm", "Broken left foot" ,"Broken left arm", "Blow to the head", "A small scratch on the left leg", "Bleeding in the right arm", "Pain in the neck", "Bleeding in the left hand", "Bleeding in the left leg","Broken left arm", "Minor wounds on the fingers"};

    string[] textsForIntervention = new string[]{"Apply cardiac message","Stop bleeding by wrapping the wound", "Immobilize the broken area","Immobilize the broken area","Check the casualty's consciousness","Cover the wound with gauze and bandage","Stop bleeding on the arm ","Immobilize the neck","Stop bleeding on the hand","Stop bleeding by wrapping the wound","Immobilize the broken area","Cover the wounds with gauze and bandage"
    };
    string[] textsForShowExamine = new string[3];
    string[] textsForShowIntervention = new string[3];
    int num;
    public void ShowExamine()
    {
       examine.SetActive(true);

       num = Random.Range(0, 4);
       System.Array.Copy(textsForExamine, num * 3, textsForShowExamine, 0, 3);

        ChangeExamine(textsForShowExamine, images[num]);
    }

    public void ChangeExamine(string[] texts,Sprite image)
    {
        examineImage.sprite = image;

        for (int i = 0; i < textsOnExaminePanel.Length; i++)
        {
            textsOnExaminePanel[i].text = texts[i];
        }

    }
    public void ShowIntervention()
    {
        intervention.SetActive(true);
        System.Array.Copy(textsForIntervention, num * 3, textsForShowIntervention, 0, 3);
        ChangeIntervention(textsForShowIntervention);
        CloseExamineContent();
    }

 

    public void ChangeIntervention(string[] texts)
    {

        for (int i = 0; i < textsOnInterventionPanel.Length; i++)
        {
            textsOnInterventionPanel[i].text = texts[i];
        }

    }
    private void CloseExamineContent()
    {
        foreach(TextMeshProUGUI txt in textsOnExaminePanel)
        {
            txt.enabled = false;
        }

        GameObject.FindGameObjectWithTag("FirstAidButton").SetActive(false);
    }
}
