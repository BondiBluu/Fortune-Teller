using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterChoices", menuName = "Choices/Make Character Choices")]
public class Choices : ScriptableObject
{
    public enum Morality{
        Great,
        Good,
        Bad,
        Evil
    }
    
    [SerializeField] string characterQuestion;
    [SerializeField] string[] playerChoices = new string[4];
    [SerializeField] string characterResponse;

    public string CharacterQuestion {get {return characterQuestion;}}
    public string[] PlayerChoice {get {return playerChoices;}}
    public string CharacterResponse {get {return characterResponse;}}
}
