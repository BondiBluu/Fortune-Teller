using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day", menuName = "Days/Make New Day", order = 1)]
public class Day : ScriptableObject
{
    public List<TruthSeekers> characters = new List<TruthSeekers>();
}
