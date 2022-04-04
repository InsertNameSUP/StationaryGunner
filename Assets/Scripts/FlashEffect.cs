using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    Image self;
    public Color firstColor;
    public Color secondColor;
    public float speed = 1;
    // Start is called before the first frame update
    void Awake()
    {
        self = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        self.color = Color.Lerp(firstColor, secondColor, Mathf.PingPong(Time.time, 1) * speed);
    }
}
