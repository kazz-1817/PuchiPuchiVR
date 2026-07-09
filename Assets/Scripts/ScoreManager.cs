using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("数字を表示するテキスト")]
    public TextMeshProUGUI scoreText;

    // 現在のつぶした回数
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    // スコアを1増やして画面を更新する
    public void AddScore()
    {
        score += 1;
        scoreText.text = "つぶした数: " + score + "回";
    }
}