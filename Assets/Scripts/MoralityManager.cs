using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoralityManager : MonoBehaviour
{
    DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
