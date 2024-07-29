using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        Menu,
        Game,
        Victory
    }

    private static State currState;

    public static int leftScore { get; private set; }
    public static int rightScore { get; private set; }

    [SerializeField] static int winScore = 2;

    public static bool player1wins { get; private set; }
    public static bool player2wins { get; private set; }

    // Singleton design pattern. Static instance of the game manager but it can only be set from this class.
    public static GameManager instance { get; private set; }

    // On awake check if the instance already exists and if it's not me. If both are true -> kill myself.
    // Else set instance to me.
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        leftScore = 0;
        rightScore = 0;

        switch(SceneManager.GetActiveScene().name)
        {
            case "Menu":
                {
                    currState = State.Menu;
                    break;
                }
            case "Game":
                {
                    currState = State.Game;
                    break;
                }
            case "Victory": 
                {
                    currState = State.Victory;
                    break;
                }
        }
        Debug.Log("GameManager is in " + currState.ToString() + " state with Left Score: " + leftScore + " and Right Score: " + rightScore);
    }

    private void Update()
    {
        //Check for win condition.
        if(leftScore == winScore)
        {
            player1wins = true;
            ChangeScene("Victory");
        } else if(rightScore == winScore)
        {
            player2wins = true;
            ChangeScene("Victory");
        }

        switch(currState)
        {
            case State.Game:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ChangeScene("Menu");
                    }
                    break;
                }
            case State.Victory:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ChangeScene("Menu");
                    }
                    break;
                }
        }
    }

    public void PlayButtonClick()
    {
        ChangeScene("Game");
    }

    public void RightScores() 
    { 
        rightScore++;
        ScoreSript.ChangeScore(leftScore, rightScore);
    }
    public void LeftScores() 
    { 
        leftScore++;
        ScoreSript.ChangeScore(leftScore, rightScore);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void resetScores()
    {
        player2wins = false;
        player1wins = false;
    }
}
