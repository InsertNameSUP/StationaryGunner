using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ScoreManager))]
public class ScoreManagerDev : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ScoreManager sm = (ScoreManager)target;
        if (GUILayout.Button("Reset Highscore"))
        {
            ScoreManager.highScore = 0;
            PlayerPrefs.SetInt("highscore", 0);
        }
    }
}
