using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    void Start()
    {
    }
    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    static string FormatScore(int score)
    {
        string formattedScore = score.ToString();
        int sLength = score.ToString().Length;
        for(int i = 0; i < 24 - sLength; i++)
        {
            formattedScore = "0" + formattedScore;
        }
        return score.ToString();
    }
    public static void AddScore(int add) {
        score = Mathf.Max(0, score + add);
        UI._scoreUI.text = FormatScore(score); // Set in function instead of update to avoid massive frame drops
        UI.instance.StartCoroutine(Util.UI.Effects.glowEffect(UI._scoreUI, 3));
    }
    public static void ResetScore()
    {
        score = 0;
    }
    public static void SetScore(int set)
    {
        score = Mathf.Max(0, set);
    }
}
