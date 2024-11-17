using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MailManager : MonoBehaviour
{
    [SerializeField] GameObject responseContainer;
    [SerializeField] GameObject letterBox;
    [SerializeField] Transform messageListContainer;
    [SerializeField] TMP_Text responseText;
    [SerializeField] Button buttonPrefab;
    [SerializeField] Button mailImage;
    [SerializeField] Button closeMailButton;
    [SerializeField] Sprite mailEmpty;
    [SerializeField] Sprite mailNotif;
    [SerializeField] GameObject numberOfUnreadMailContainer;
    [SerializeField] TMP_Text numberOfUnreadMailText;
    public List<string> unreadMail = new List<string>();
    public List<string> readMail = new List<string>();
    DialogueManager dialogueManager;

    void Awake(){
        responseContainer.SetActive(false);
        letterBox.SetActive(false);   
        dialogueManager = FindObjectOfType<DialogueManager>();
        numberOfUnreadMailContainer.SetActive(false);
    }

    public void OpenMessageList(){
        closeMailButton.interactable = false;
        responseContainer.SetActive(true);
        CheckIfNewMail();
        GenerateButtons();
    }

    public void CloseMessageList(){
        responseContainer.SetActive(false);
        letterBox.SetActive(false);
        StartCoroutine(dialogueManager.ComeIntoRoom());
    }

    public void GenerateButtons(){
        foreach (Transform button in messageListContainer)
        {
            Destroy(button.gameObject);
        }

        foreach (string mail in unreadMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
            button.GetComponentInChildren<TMP_Text>().text = "New Mail";
            button.onClick.AddListener(() => MakeUnreadLetterRead(mail));
        }

        foreach (string mail in readMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
            button.GetComponentInChildren<TMP_Text>().text = "Read Mail";
            button.onClick.AddListener(() => OpenLetter(mail));
        }
    }

    public void OpenLetter(string contents){
        letterBox.SetActive(true);
        responseText.text = contents;
    }

    public void MakeUnreadLetterRead(string contents){
        //read letter first, then remove from unread mail and add to read mail
        OpenLetter(contents);
        unreadMail.Remove(contents);
        readMail.Add(contents);
        CheckIfNewMail();
        GenerateButtons();
    }

    public void CheckIfNewMail(){
        if(unreadMail.Count > 0){
            numberOfUnreadMailContainer.SetActive(true);
            numberOfUnreadMailText.text = unreadMail.Count.ToString();
            mailImage.GetComponent<Image>().sprite = mailNotif;
        } 
        else if(unreadMail.Count == 0){
            numberOfUnreadMailContainer.SetActive(false);
            mailImage.GetComponent<Image>().sprite = mailEmpty;
            closeMailButton.interactable = true;
        }
    }

    public void DisableMailButton(){
        mailImage.interactable = false;
    }

    public void EnableMailButton(){
        mailImage.interactable = true;
    }

}
