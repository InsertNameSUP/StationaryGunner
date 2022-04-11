using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public Sound Play(string name, bool loop = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogError("Sound File Not Found!"); return null; }
        s.source.loop = loop;
        s.source.Play();
        return s;
    }
    public Sound FadeIn(string name, float fadeInSpeed, float targetVolume, bool loop = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogError("Sound File Not Found!"); return null; }
        s.source.volume = 0;
        s.source.loop = loop;
        s.source.Play();
        StartCoroutine(DoFadeIn(s, 1f, targetVolume));
        return s;
    }
    IEnumerator DoFadeIn(Sound s, float fadeInSpeed, float targetVolume)
    {
        float v = s.source.volume;
        while(v < targetVolume)
        {
            v += fadeInSpeed * 0.001f;
            s.source.volume = v;
            yield return null;
        }
        s.source.volume = v;
    } // Internal
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) { Debug.LogError("Sound File Not Found!"); return; }
        s.source.Stop();
    }
    public void Stop(Sound sound)
    {
        sound.source.Stop();
    }
}
