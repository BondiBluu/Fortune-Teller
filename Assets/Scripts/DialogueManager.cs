using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject character;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        character.SetActive(false);
        StartCoroutine(KnockOnDoor());
    }

    public IEnumerator KnockOnDoor()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Knock on door");
        character.SetActive(true);
    }
}
