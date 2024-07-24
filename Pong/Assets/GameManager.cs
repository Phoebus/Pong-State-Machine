using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }

        leftScore = 0;
        rightScore = 0;
    }

    public void RightScores() { rightScore++; Debug.Log("The score is " + leftScore + " : " + rightScore); }
    public void LeftScores() { leftScore++; Debug.Log("The score is " + leftScore + " : " + rightScore); }
}
