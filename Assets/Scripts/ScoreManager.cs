using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("数字を表示するテキスト")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI redScoreText;
    public TextMeshProUGUI yellowScoreText;
    public TextMeshProUGUI greenScoreText;
    public TextMeshProUGUI blueScoreText;

    // 現在のつぶした回数
    private int score = 0;
    private int redScore = 0;
    private int yellowScore = 0;
    private int greenScore = 0;
    private int blueScore = 0;

    void Awake()
    {
        instance = this;
    }

    // スコアを1増やして画面を更新する
    public void AddScore(string puchiTag)
    {
        score += 1;
        scoreText.text = "つぶした数: " + score + "回";

        switch (puchiTag.ToLower())
        {
            case "red":
                redScore += 1;
                if (redScoreText != null) redScoreText.text = "    Red: " + redScore + "回";
                break;
            case "yellow":
                yellowScore += 1;
                if (yellowScoreText != null) yellowScoreText.text = "Yellow: " + yellowScore + "回";
                break;
            case "green":
                greenScore += 1;
                if (greenScoreText != null) greenScoreText.text = "Green: " + greenScore + "回";
                break;
            case "blue":
                blueScore += 1;
                if (blueScoreText != null) blueScoreText.text = "   Blue: " + blueScore + "回";
                break;
            default:
                // タグが設定されていない、または名前がズレている場合の保険
                Debug.LogWarning("ScoreManager: 登録されていないタグです -> " + puchiTag);
                break;
        }
    }
}