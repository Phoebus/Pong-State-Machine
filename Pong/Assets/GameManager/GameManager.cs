using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

        leftScore = 0;
        rightScore = 0;
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
