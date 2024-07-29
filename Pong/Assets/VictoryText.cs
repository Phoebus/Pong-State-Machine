using TMPro;
using UnityEngine;

public class VictoryText : MonoBehaviour
{

    private void Start()
    {
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        GameManager gameManager = FindObjectOfType<GameManager>();

        if(GameManager.player1wins)
        {
            text.text = "Player 1 Wins!";
            gameManager.resetScores();
        } else if (GameManager.player2wins)
        {
            text.text = "Player 2 Wins!";
            gameManager.resetScores();
        }
    }
}
