using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public static int highScore;
    public UI uiManager;
    void SaveHighscore()
    {
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        Gunner.OnDeath += SaveHighscore;
        uiManager.highscoreUI.text = FormatScore(highScore);
    }
    private void OnDestroy()
    {
        Gunner.OnDeath -= SaveHighscore;
    }
    // Update is called once per frame
    void Update()
    {
    }
    static string FormatScore(int score)
    {
        return score.ToString();
    }
    public static void AddScore(int add) {
        score = Mathf.Max(0, score + add);
        UI._scoreUI.text = FormatScore(score); // Set in function instead of update to avoid massive frame drops
        UI.instance.StartCoroutine(Util.UI.Effects.glowEffect(UI._scoreUI, 3));
        if (score > highScore)
        {
            highScore = score;
            UI._highscoreUI.text = FormatScore(highScore);
            UI.instance.StartCoroutine(Util.UI.Effects.glowEffect(UI._highscoreUI, 3));
        }
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
