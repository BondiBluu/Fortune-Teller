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
    [SerializeField] TMP_Text charaResponse;
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

        foreach (string letter in unreadMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
        }

        foreach (string letter in readMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
        }
    }

    public void OpenLetter(){
        letterBox.SetActive(true);
        
    }

}
