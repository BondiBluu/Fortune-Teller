using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Timeline;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Character/Make New Character")]
public class TruthSeekers : ScriptableObject
{
    [SerializeField] string cName;
    [SerializeField] string fact;
    [SerializeField] int age;
    [SerializeField] char gender;
    [SerializeField] string occupation;
    [SerializeField] Choices problems;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] TimelineAsset nodClip;
    [SerializeField] TimelineAsset walkInClip;
    [SerializeField] TimelineAsset walkOutClip;

    //getting and setting
    public string CName { get {return cName;} }
    public string Fact { get {return fact;} }
    public int Age { get {return age;} }
    public char Gender {get {return gender;} }
    public string Occupation { get {return occupation;} }
    public Choices Problems { get {return problems;} } 
    public Sprite FrontSprite { get {return frontSprite;}}
    public Sprite BackSprite { get {return backSprite;}}
    public TimelineAsset NodClip { get {return nodClip;} }
    public TimelineAsset WalkInClip { get {return walkInClip;}}
    public TimelineAsset WalkOutClip { get {return walkOutClip;}}
    }
