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
    [SerializeField] Button[] choiceButtons;
    DayManager dayManager;
    ChoiceManager choiceManager;

    CutsceneManager cutsceneManager;
    // Start is called before the first frame update
    void Start()
    {
        cutsceneManager = FindObjectOfType<CutsceneManager>();
        dayManager = FindObjectOfType<DayManager>();
        choiceManager = FindObjectOfType<ChoiceManager>();
        character.SetActive(false);
        StartCoroutine(KnockOnDoor());
        questionBox.SetActive(false);
    }

    public IEnumerator KnockOnDoor()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Knock on door");
        character.SetActive(true);
        cutsceneManager.PlayScene(cutsceneManager.characterGoesIntoRoom);
        yield return new WaitForSeconds((float)cutsceneManager.characterGoesIntoRoom.duration + 1.0f);
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

        for(int i = 0; i < choiceButtons.Length; i++){
            int choiceIndex = i;
            choiceButtons[i].GetComponentInChildren<TMP_Text>().text = currentDay.Characters[character].Problems.PlayerChoices[i].Choice;

            choiceButtons[i].onClick.RemoveAllListeners();
            choiceButtons[i].onClick.AddListener(() => StartCoroutine(AnswerQuestion(day, character, choiceIndex)));
        }
    }

    public IEnumerator AnswerQuestion(int day, int character, int choice){
        yield return new WaitForSeconds(2.0f);
        questionBox.SetActive(false);
        dialogueBox.SetActive(true);

        dialogueText.text = dayManager.days[day].Characters[character].Problems.CharacterResponse;

        MoralityChoices.MoralChoice morality = dayManager.days[day].Characters[character].Problems.PlayerChoices[choice].Morality;

        switch(morality){
            case MoralityChoices.MoralChoice.Good:
                choiceManager.goodChoiceTally++;
            break;
            case MoralityChoices.MoralChoice.Fine:
                choiceManager.fineChoiceTally++;
            break;
            case MoralityChoices.MoralChoice.Bad:
                choiceManager.badChoiceTally++;
            break;
            case MoralityChoices.MoralChoice.Evil:
                choiceManager.evilChoiceTally++;
            break;
            default:
                Debug.Log("Morality choice not found.");
            break;
         }

         Debug.Log($"Good Choices: {choiceManager.goodChoiceTally}, Fine Choices: {choiceManager.fineChoiceTally}, Bad Choices: {choiceManager.badChoiceTally}, Evil Choices: {choiceManager.evilChoiceTally}");

         StartCoroutine(LeaveRoom());
    }

    public IEnumerator LeaveRoom(){
        yield return new WaitForSeconds(1.0f);
        dialogueBox.SetActive(false);
        cutsceneManager.PlayScene(cutsceneManager.characterLeavesRoom);
        yield return new WaitForSeconds((float)cutsceneManager.characterLeavesRoom.duration + 1.0f);
        character.SetActive(false);
    }
}


