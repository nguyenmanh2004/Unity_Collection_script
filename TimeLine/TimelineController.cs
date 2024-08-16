using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    private PlayableDirector playableDirector;
   
  

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.stopped += OnTimelineFinished;

    }

    private void OnTimelineFinished(PlayableDirector obj)
    {
        // Thực hiện logic sau khi timeline kết thúc
        RunScriptAfterTimeline();
    }

    private void RunScriptAfterTimeline() => SceneManager.LoadScene(1);
}