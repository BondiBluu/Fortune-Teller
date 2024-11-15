using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    public TimelineAsset characterGoesIntoRoom;
    public TimelineAsset characterLeavesRoom;
    
    public void PlayScene(TimelineAsset cutscene)
    {
        //assigning the timeline asset to the director
        director.playableAsset = cutscene;

        //playing the cutscene
        director.Play();
    }
}
