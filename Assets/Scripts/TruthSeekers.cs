using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TruthSeekers : ScriptableObject
{
    string cName;
    string fact;
    int age;
    string occupation;
    string problem;
    List<string[]> solutions;
    string[] dialogue;
    Dictionary<string, AnimationClip> animations; // key: animation name, value: animation clip

    //getting and setting
    public string CName { get {return cName;} }

    public string Fact { get {return fact;} }
    public int Age { get {return age;} }
    public string Occupation { get {return occupation;} }
    public string Problem { get {return problem;} }
    public List<string[]> Solutions { get {return solutions;} }
    public string[] Dialogue { get {return dialogue;} }
    public Dictionary<string, AnimationClip> Animations { get {return animations;} }
}
