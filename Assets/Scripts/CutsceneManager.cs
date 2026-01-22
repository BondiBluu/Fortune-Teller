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
    public TimelineAsset characterNod;
    public TimelineAsset nextMorning;

    public void PlayScene(TimelineAsset cutscene)
    {
        //assigning the timeline asset to the director
        director.playableAsset = cutscene;

        //playing the cutscene
        director.Play();
    }

      public void ChangeCharacter(TruthSeekers character)
    {
        characterGoesIntoRoom = character.WalkInClip;
        characterLeavesRoom = character.WalkOutClip;
        characterNod = character.NodClip;
    }
}
