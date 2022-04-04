using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Color targetColor1;
    public Color targetColor2;
    public float speed;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();   
    }
    // Update is called once per frame
    void Update()
    {
        sr.color = Color.Lerp(targetColor1, targetColor2, Mathf.PingPong(Time.time * speed, 1));
    }
}
