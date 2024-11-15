using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day", menuName = "Days/Make New Day")]
public class Day : ScriptableObject
{
    [SerializeField] List<TruthSeekers> characters = new List<TruthSeekers>();

    public List<TruthSeekers> Characters {get {return characters;}}
}
