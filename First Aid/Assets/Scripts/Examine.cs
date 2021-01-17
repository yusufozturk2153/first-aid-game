using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Examine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] textsOnExaminePanel;
    [SerializeField] Sprite[] images;
    [SerializeField] Image examineImage;

    public Injury[] injuriesForShow = new Injury[3];

    Injury[] injuryList = new Injury[12];

    public void ShowExamine()
    {

        gameObject.SetActive(true);

        AddInjuries();

        int randomNumber = Random.Range(0, 4);
        System.Array.Copy(injuryList, randomNumber * 3, injuriesForShow, 0, 3);
        injuriesForShow = injuriesForShow.OrderBy(i => i.Importance).ToArray();
        StartCursorMode();
        ChangeExamine(injuriesForShow, images[randomNumber]);
    }

    public void ChangeExamine(Injury[] injuries, Sprite image)
    {
        examineImage.sprite = image;

        for (int i = 0; i < textsOnExaminePanel.Length; i++)
        {
            textsOnExaminePanel[i].text = injuries[i].Name;
        }

    }

    public void CloseExamineContent()
    {
        foreach (TextMeshProUGUI txt in textsOnExaminePanel)
        {
            txt.enabled = false;
        }

        GameObject.FindGameObjectWithTag("FirstAidButton").SetActive(false);
    }

    private static void StartCursorMode()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    void AddInjuries()
    {


        string[] examines = new string[] { "The heart beat stopped", "Bleeding in the left arm", "Broken left foot", "Broken left arm", "Blow to the head", "A small scratch on the left leg", "Bleeding in the right arm", "Pain in the neck", "Broken fingers in the left hand", "Bleeding in the left leg", "Broken left arm", "Minor wounds on the fingers" };

        string[] interventions = new string[]{"Apply cardiac message","Stop bleeding by wrapping the wound", "Immobilize the broken area","Immobilize the broken area","Check the casualty's consciousness","Cover the wound with gauze ","Stop bleeding on the arm ","Immobilize the neck","Immobilize the fingers","Stop  bleeding by wrapping the wound","Immobilize the broken area","Cover the wounds with gauze"
    };

        int[] importanceList = new int[] { 1, 2, 3, 2, 1, 3, 2, 1, 3, 1, 2, 3 };



        for (int i = 0; i < examines.Length; i++)
        {
            Injury injury = new Injury();

            injury.Importance = importanceList[i];
            injury.Name = examines[i];
            injury.Intervention = interventions[i];

            injuryList[i] = injury;
        }

    }

}
