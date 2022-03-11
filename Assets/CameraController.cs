﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void Shake(float duration, float magnitude) {
        StartCoroutine(Util.Effects.Camera.CameraShake.Shake(Camera.main.transform, duration, magnitude));
    }

}
