using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public List<Day> days = new List<Day>();
    public int currentDay = 0;
    public int currentCharacter = 0;

    //cycle through each character in a day
    public void NextCharacter()
    {
        //if there are more characters in the day, move to the next character. If not, move to the next day.
        if(currentCharacter < days[currentDay].Characters.Count - 1)
        {
            currentCharacter++;
        }
        else
        {
            currentCharacter = 0;

            //if there are more days, move to the next day
            if(currentDay < days.Count - 1)
            {
                currentDay++;
            }
        }
    }
}
