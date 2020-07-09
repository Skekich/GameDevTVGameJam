using UnityEngine;
using TMPro;

public class ScoreUIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore;

    public int CurrentScore => currentScore;

    private void OnEnable()
    {
        EventHandler.OnInvokeScore -= AddScore;
        EventHandler.OnInvokeScore += AddScore;
    }

    private void Start()
    {
        currentScore = 0;
        scoreText.text = $"Score {currentScore.ToString()}";
    }

    private void AddScore(int score)
    {
        if (score == 0)
        {
            if (currentScore <= 0) return;
            currentScore = 0;
            scoreText.text = $"Score {currentScore.ToString()}";
            return;
        }
        currentScore += score;
        scoreText.text = $"Score {currentScore.ToString()}";
    }

    private void OnDisable()
    {
        EventHandler.OnInvokeScore -= AddScore;
    }
}