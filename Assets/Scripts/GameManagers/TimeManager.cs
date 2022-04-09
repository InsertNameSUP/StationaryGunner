using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range(0, 1)]
   public float slowMotionTimeScale;
    private float startTimeScale;
    private float startFixedDeltaTime;
    private void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
        GameStateManager.OnGameStateChange += ShopMenuSlow;
    }
    void ShopMenuSlow()
    {
        switch(GameStateManager.GetGameState()) {
            case GameStateManager.GameState.Paused:

                break;
            case GameStateManager.GameState.Shop:
                StartSlowMotion(true);
                break;

            case GameStateManager.GameState.Playing:
                StopSlowMotion();
                break;

        }
    }
    private void Update() // Testing
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartSlowMotion(true);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopSlowMotion();
        }
    }
    IEnumerator smoothSlow(Sound s)
    {
        while(s.source.pitch > s.pitch * slowMotionTimeScale * 5)
        {
            s.source.pitch -= 0.01f * slowMotionTimeScale;
            yield return null;
        }
    }
    IEnumerator smoothReturn(Sound s)
    {
        while (s.source.pitch < s.pitch)
        {
            s.source.pitch += 0.01f * slowMotionTimeScale;
            yield return null;
        }
    }
    void StartSlowMotion(bool includeAudio)
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
        StartCoroutine(UI.vignetteFadeIn(0.4f, 0.01f));
        foreach(Sound s in AudioManager.instance.sounds)
        {
            StartCoroutine(smoothSlow(s));
        }
    }
    void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
        StartCoroutine(UI.vignetteFadeOut(0.01f));
        foreach (Sound s in AudioManager.instance.sounds)
        {
            StartCoroutine(smoothReturn(s));
        }
    }
}
