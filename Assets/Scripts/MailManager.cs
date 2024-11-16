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
    public List<string> unreadMail = new List<string>();
    public List<string> readMail = new List<string>();

    void Awake(){
        responseContainer.SetActive(false);
        letterBox.SetActive(false);
        
    }

    public void OpenMessageList(){
        responseContainer.SetActive(true);
        GenerateButtons();
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
        GenerateButtons();
    }

}
