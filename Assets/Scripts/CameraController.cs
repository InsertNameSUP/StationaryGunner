using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    Sound ambientMusic;
    // Start is called before the first frame update
    void Start() // Order of execution can suck my dick
    {
        ambientMusic = AudioManager.instance.FadeIn("Main Theme", 3f, 0.3f, true);
    }
    private void Awake()
    {
        Gunner.OnDeath += StopGameMusic;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
    }
    void StopGameMusic ()
    {
        AudioManager.instance.Stop(ambientMusic);
    }
    public void Shake(float duration, float magnitude) {
        StartCoroutine(Util.Effects.Camera.CameraShake.Shake(Camera.main.transform, duration, magnitude));
    }

}
