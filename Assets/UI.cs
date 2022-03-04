using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [Header("Health")]
    public RectTransform healthBar;
    [Range(0, 10)] public float healthBarWidth = 50f;
    [Range(0, 10)] public int testInt = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        Variables test = new Variables();
        test.OnChange<int>(ref testInt);
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.sizeDelta = Vector2.Lerp(healthBar.sizeDelta, new Vector2(healthBarWidth * Gunner.health, healthBar.sizeDelta.y), Time.deltaTime * 3);
    }
}
