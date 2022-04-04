using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [Header("Score")]
    public CanvasGroup loadInCanvas;
    public static TMP_Text _scoreUI;
    public TMP_Text scoreUI;
    public static TMP_Text _highscoreUI;
    public TMP_Text highscoreUI;
    public static UI instance;
    [Header("Health")]
    public RectTransform healthBar;
    [Range(0, 10)] public float healthBarWidth = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadInFade(0.125f));
    }
    void Awake()
    {
        instance = this;
        _scoreUI = scoreUI;
        _highscoreUI = highscoreUI;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.sizeDelta = Vector2.Lerp(healthBar.sizeDelta, new Vector2(Gunner.health * healthBarWidth, healthBar.sizeDelta.y), Time.deltaTime * 3);
    }


    IEnumerator LoadInFade(float speed)
    {
        float a = 1;
        while (a > 0)
        {
            a -= 0.05f * speed;
            loadInCanvas.alpha = a;
            yield return null;
        }
    }
}
