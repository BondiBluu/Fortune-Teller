using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{
    public int goodChoiceTally = 0;
    public int fineChoiceTally = 0;
    public int badChoiceTally = 0;
    public int evilChoiceTally = 0;

    [SerializeField] GameObject moonternSprite;
    [SerializeField] Sprite goodMoontern;
    [SerializeField] Sprite fineMoontern;
    [SerializeField] Sprite badMoontern;
    [SerializeField] Sprite evilMoontern;

    public void InputTallies(){
        int[] choiceTallies = {goodChoiceTally, fineChoiceTally, badChoiceTally, evilChoiceTally};
        FindMaxIndex(choiceTallies);
    }

    public void FindMaxIndex(int[] choiceTallies){
        int maxIndex = 0;

        //if the current index is greater than the max index, set the max index to the current index
        for (int i = 0; i < choiceTallies.Length; i++)
        {
            if (choiceTallies[i] > choiceTallies[maxIndex])
            {
                maxIndex = i;
            }
            //if a max index is ties, randomly choose between the two
            else if (choiceTallies[i] == choiceTallies[maxIndex])
            {
                if (Random.Range(0, 2) == 0)
                {
                    Debug.Log("Random Choice");
                    maxIndex = i;
                }
            }
        }

        switch (maxIndex)
        {
            case 0:
                //grab the image child og th game object
                moonternSprite.GetComponentInChildren<Image>().sprite = goodMoontern;
                Debug.Log("Good Moontern");
                break;
            case 1:
                moonternSprite.GetComponentInChildren<Image>().sprite = fineMoontern;
                Debug.Log("Fine Moontern");
                break;
            case 2:
                moonternSprite.GetComponentInChildren<Image>().sprite = badMoontern;
                Debug.Log("Bad Moontern");
                break;
            case 3:
                moonternSprite.GetComponentInChildren<Image>().sprite = evilMoontern;
                Debug.Log("Evil Moontern");
                break;
            default:
                Debug.Log("No Moontern");
                break;
        }
    }
}