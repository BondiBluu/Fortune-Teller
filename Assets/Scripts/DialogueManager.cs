using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject character;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    [SerializeField] GameObject questionBox;
    [SerializeField] TMP_Text characterName;
    [SerializeField] TMP_Text charaAge;
    [SerializeField] TMP_Text charaOccupation;
    [SerializeField] TMP_Text charaFact;
    [SerializeField] TMP_Text charaQuestion;
    [SerializeField] Button[] choices;
    DayManager dayManager;

    CutsceneManager cutsceneManager;
    // Start is called before the first frame update
    void Start()
    {
        cutsceneManager = FindObjectOfType<CutsceneManager>();
        dayManager = FindObjectOfType<DayManager>();
        character.SetActive(false);
        StartCoroutine(KnockOnDoor());
        questionBox.SetActive(false);
    }

    public IEnumerator KnockOnDoor()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Knock on door");
        character.SetActive(true);
        cutsceneManager.KnockOnDoor();
        yield return new WaitForSeconds((float)cutsceneManager.characterGoesIntoRoom.duration + 1.0f);
        Debug.Log("Done.");
        DisplayAdviceBox(dayManager.currentDay, dayManager.currentCharacter);
    }

    public void DisplayAdviceBox(int day, int character){
        questionBox.SetActive(true);
        Day currentDay = dayManager.days[day];
        characterName.text = currentDay.Characters[character].CName;
        charaAge.text = $"Age: {currentDay.Characters[character].Age}";
        charaOccupation.text = currentDay.Characters[character].Occupation;
        charaFact.text = currentDay.Characters[character].Fact;
        charaQuestion.text = currentDay.Characters[character].Problems.CharacterQuestion;

        for(int i = 0; i < choices.Length; i++){
            choices[i].GetComponentInChildren<TMP_Text>().text = currentDay.Characters[character].Problems.PlayerChoices[i].Choice;

            choices[i].onClick.RemoveAllListeners();
            choices[i].onClick.AddListener(() => AnswerQuestion(day, character, i));
        }
    }

    public IEnumerator AnswerQuestion(int day, int character, int choice){
        yield return new WaitForSeconds(2.0f);
        questionBox.SetActive(false);
        dialogueBox.SetActive(true);
        
        

    }
}
