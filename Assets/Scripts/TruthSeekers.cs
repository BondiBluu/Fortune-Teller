using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Make New Character")]
public class TruthSeekers : ScriptableObject
{
    [SerializeField] string cName;
    [SerializeField] string fact;
    [SerializeField] int age;
    [SerializeField] string occupation;
    [SerializeField] Choices problems;
    [SerializeField] Dictionary<string, AnimationClip> animations; // key: animation name, value: animation clip

    //getting and setting
    public string CName { get {return cName;} }
    public string Fact { get {return fact;} }
    public int Age { get {return age;} }
    public string Occupation { get {return occupation;} }
    public Choices Problems { get {return problems;} } 
    public Dictionary<string, AnimationClip> Animations { get {return animations;} }
}
