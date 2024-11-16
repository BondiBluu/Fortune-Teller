using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    public int goodChoiceTally = 0;
    public int fineChoiceTally = 0;
    public int badChoiceTally = 0;
    public int evilChoiceTally = 0;

    [SerializeField] Sprite goodMoontern;
    [SerializeField] Sprite fineMoontern;
    [SerializeField] Sprite badMoontern;
    [SerializeField] Sprite evilMoontern;

    public void FindMaxMoralChoice(){
        //find the moral choice with the highest tally, and set the moontern sprite to that choice
        int max = Mathf.Max(goodChoiceTally, fineChoiceTally, badChoiceTally, evilChoiceTally);

        

        
    }
}