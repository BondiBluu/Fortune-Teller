using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Choice", menuName = "Choices/ Make Player Choices")]
public class MoralityChoices : ScriptableObject
{
    public enum MoralChoice{
        Good,
        Fine,
        Bad,
        Evil
    }
    [SerializeField] MoralChoice morality;
    [SerializeField] string choice;

    public MoralChoice Morality {get {return morality;}}
    public string Choice {get {return choice;}}
}
