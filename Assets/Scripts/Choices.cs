using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterChoices", menuName = "Choices/Make Character Choices")]
public class Choices : ScriptableObject
{
    
    [SerializeField] string characterQuestion;
    [SerializeField] MoralityChoices[] playerChoices = new MoralityChoices[4];
    [SerializeField] string characterResponse;

    public string CharacterQuestion {get {return characterQuestion;}}
    public MoralityChoices[] PlayerChoice {get {return playerChoices;}}
    public string CharacterResponse {get {return characterResponse;}}
}
