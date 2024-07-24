using UnityEngine;

public class Goal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.GetComponent<Ball>() != null)
        {
            Ball ballScript = collision.GetComponent<Ball>();
            if(ballScript.getMovementDirection() == -1)
            {
                Debug.Log("Right Player scores!!!");
            } else if (ballScript.getMovementDirection() == 1)
            {
                Debug.Log("Left player scores!!!");
            }

            ballScript.ResetPos();
        }

    }

}
