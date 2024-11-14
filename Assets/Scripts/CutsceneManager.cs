using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] TimelineAsset characterGoesIntoRoom;
    public bool isPlaying = false;
    
    public bool KnockOnDoor()
    {
        isPlaying = true;
        //assigning the timeline asset to the director
        director.playableAsset = characterGoesIntoRoom;

        //playing the cutscene
        director.Play();
        return isPlaying;
    }
}
