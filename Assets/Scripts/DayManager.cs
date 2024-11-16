using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public List<Day> days = new List<Day>();
    public int currentDay = 0;
    public int currentCharacter = 0;
    [SerializeField] GameObject nextMorningPanel;
    DialogueManager dialogueManager;
    MailManager mailManager;
    CutsceneManager cutsceneManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        mailManager = FindObjectOfType<MailManager>();
        cutsceneManager = FindObjectOfType<CutsceneManager>();
    }

    //cycle through each character in a day
    public IEnumerator NextCharacter()
    {
        //if there are more characters in the day, move to the next character. If not, move to the next day.
        if(currentCharacter < days[currentDay].Characters.Count - 1)
        {
            currentCharacter++;
            StartCoroutine(dialogueManager.ComeIntoRoom());
        }
        else
        {
            //if there are more days, move to the next day. If not, end the game.
            if(currentDay < days.Count - 1)
            {
                currentDay++;
                currentCharacter = 0;
                nextMorningPanel.SetActive(true);
                cutsceneManager.PlayScene(cutsceneManager.nextMorning);
                yield return new WaitForSeconds((float)cutsceneManager.nextMorning.duration + 1.0f);
                nextMorningPanel.SetActive(false);
                mailManager.CheckIfNewMail();
            }
            else
            {
                Debug.Log("Game Over");
            }
        }
    }
}
