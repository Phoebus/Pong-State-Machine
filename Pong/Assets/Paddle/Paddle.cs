using UnityEngine;

public class Paddle : MonoBehaviour
{
    public MovingState movingState;
    public IdleState idleState;

    private State currState;

    [SerializeField] private bool secondPlayer = false;

    public float input { get; private set; }

    private void Start()
    {
        currState = idleState;
        currState.Enter();
    }

    private void FixedUpdate()
    {
        if(secondPlayer)
        {
            input = Input.GetAxisRaw("Vertical1");
        } else
        {
            input = Input.GetAxisRaw("Vertical2");
        }

        if(currState.isComplete)
        {
            if(input != 0)
            {
                currState.Exit();
                currState = movingState;
                currState.Enter();
            } else
            {
                currState.Exit();
                currState = idleState;
                currState.Enter();
            }
        }
        currState.PhysicsProcess();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.GetComponent<Ball>() != null)
        {
            collision.GetComponent<Ball>().OnPaddleCollision();
        }

    }
}
