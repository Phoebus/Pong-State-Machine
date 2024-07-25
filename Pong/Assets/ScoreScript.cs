using TMPro;
using UnityEngine;

public class ScoreSript : MonoBehaviour
{
    private static TextMeshProUGUI scoreText = null;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public static void ChangeScore(int leftScore, int rightScore)
    {
        scoreText.text = "" + leftScore + " : " + rightScore;
    }
}
