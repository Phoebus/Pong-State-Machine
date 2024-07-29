using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        Menu,
        Game
    }

    private State currState;

    public int leftScore { get; private set; }
    public int rightScore { get; private set; }

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
        }
        Debug.Log("GameManager is in " + currState.ToString() + " state.");
    }

    private void Update()
    {
        switch(currState)
        {
            case State.Game:
                {
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        currState = State.Menu;
                        ChangeScene("Menu");
                    }
                    break;
                }
        }
    }

    public void PlayButtonClick()
    {
        currState = State.Game;
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
}
