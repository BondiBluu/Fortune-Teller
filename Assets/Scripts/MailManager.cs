using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MailManager : MonoBehaviour
{
    [SerializeField] GameObject responseContainer;
    [SerializeField] GameObject letterBox;
    [SerializeField] GameObject questionBox;
    [SerializeField] Transform messageListContainer;
    [SerializeField] TMP_Text charaResponse;
    [SerializeField] Button buttonPrefab;
    public List<string> unreadMail = new List<string>();
    public List<string> readMail = new List<string>();

    void Start(){
        letterBox.SetActive(false);
        responseContainer.SetActive(false);
    }

    public void OpenMessageList(){
        responseContainer.SetActive(true);
        questionBox.SetActive(true);
        GenerateButtons();
    }

    public void GenerateButtons(){
        foreach (Transform child in responseContainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (string letter in unreadMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
            button.GetComponentInChildren<TMP_Text>().text = letter;
        }

        foreach (string letter in readMail)
        {
            Button button = Instantiate(buttonPrefab, messageListContainer);
            button.GetComponentInChildren<TMP_Text>().text = letter;
        }
    }

    public void OpenLetter(){
        letterBox.SetActive(true);
        
    }

}
