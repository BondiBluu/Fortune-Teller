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
        DisplayAdviceBox();
    }

    public void DisplayAdviceBox(){
        questionBox.SetActive(true);
        Day dayOne = dayManager.days[0];
        characterName.text = dayOne.Characters[0].CName;
        charaAge.text = $"Age: {dayOne.Characters[0].Age}";
        charaOccupation.text = dayOne.Characters[0].Occupation;
        charaFact.text = dayOne.Characters[0].Fact;
        charaQuestion.text = dayOne.Characters[0].Problems.CharacterQuestion;

        
    }
}
