using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Problem", menuName = "Choices/Make Character Problem")]
public class Choices : ScriptableObject
{
    [TextArea (3, 10)]
    [SerializeField] string characterQuestion;
    [SerializeField] MoralityChoices[] playerChoices = new MoralityChoices[4];
    
    [TextArea (3, 10)]
    [SerializeField] string characterResponse;

    public string CharacterQuestion {get {return characterQuestion;}}
    public MoralityChoices[] PlayerChoices {get {return playerChoices;}}
    public string CharacterResponse {get {return characterResponse;}}
}
