using UnityEngine;

public class MovingState : State
{
    [SerializeField] private float speed;

    public Camera cam;
    public SpriteRenderer spriteRenderer;
    public Transform objTransform;

    public override void Enter()
    {
        Debug.Log("Entered Moving!!!");
        isComplete = false;
    }

    public override void Exit()
    {
        Debug.Log("Exited moving. . .");
    }

    public override void PhysicsProcess()
    {
        float movement = script.input * speed * Time.deltaTime;

        if(script.input == 0)
        {
            isComplete = true;
            return;
        }

        if (!checkForBorderCollision(movement))
        {
            objTransform.position += new Vector3(0, movement, 0);
        }
    }

    public override void Process()
    {
        
    }

    private bool checkForBorderCollision(float movement)
    {
        // Get the height of the sprite and multiply it by the scale on the Y axis.
        float paddleHeight = spriteRenderer.sprite.bounds.size.y * objTransform.lossyScale.y;

        float topEdge = objTransform.position.y + paddleHeight / 2;
        float bottomEdge = objTransform.position.y - paddleHeight / 2;

        // Check if topEdge will go over the screen or if bottomEdge will go under the screen.
        if (cam.WorldToViewportPoint(new Vector3(0, topEdge + movement, 0)).y < 1
            && cam.WorldToViewportPoint(new Vector3(0, bottomEdge + movement, 0)).y > 0)
        {
            return false;
        }

        return true;
    }
}
