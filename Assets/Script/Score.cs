using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
        StartCoroutine(IncrementScore());
    }

    IEnumerator IncrementScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); 
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
