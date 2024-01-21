using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance { get; private set; }

    [SerializeField] private List<Image> scoreNumbers;
    [SerializeField] private int score;
    [SerializeField] private Text finalScoreText;

    private void Awake()
    {
        if (ScoreDisplay.Instance != null)
        {
            Destroy(ScoreDisplay.Instance.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Update UI
        List<int> d = DigitExtract(score);

        for (int i = 0; i < d.Count; i++)
        {
            scoreNumbers[i].sprite = SpriteAssets.Instance.GetNumberSprite(d[i]);
        }
    }

    private List<int> DigitExtract(int num)
    {
        List<int> digits = new();

        while (num != 0)    
        {
            digits.Add(num % 10);

            num /= 10;
        }

        return digits;
    }

    public void SetFinalScoreText()
    {
        finalScoreText.text = score.ToString();
    }
}
