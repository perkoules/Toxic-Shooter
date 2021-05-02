using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score Instance { get; set; }
    private TextMeshProUGUI scoreText;
    private int currentScore = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShowScore(int addedScore)
    {
        currentScore += addedScore;
        scoreText.text = currentScore.ToString();
    }
}
