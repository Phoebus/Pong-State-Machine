using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private SpriteRenderer spriteRenderer;
    private Camera cam;

    private float angle;
    private int mirrorDirection;
    private int movementDirection;

    public int getMovementDirection() { return movementDirection; }

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        RandomizeStart();
    }

    void Update()
    {
        Vector2 movement = new Vector2(speed * movementDirection, (speed * movementDirection) * angle * mirrorDirection) * Time.deltaTime;
        
        if(CheckForBorderCollision(movement.y))
        {
            angle *= -1;
        }

        transform.position += new Vector3(movement.x, movement.y, 0);
    }

    public void OnPaddleCollision()
    {

        angle *= -1;
        movementDirection *= -1;

    }

    public void ResetPos()
    {
        float startX = Screen.width / 2;
        float startY = Screen.height / 2;

        this.transform.position = new Vector3(startX, startY, this.transform.position.z);
    }

    private bool CheckForBorderCollision(float movement)
    {
        // Get the height of the sprite and multiply it by the scale on the Y axis.
        float ballHeight = spriteRenderer.sprite.bounds.size.y * transform.lossyScale.y;

        float topEdge = transform.position.y + ballHeight / 2;
        float bottomEdge = transform.position.y - ballHeight / 2;

        // Check if topEdge will go over the screen or if bottomEdge will go under the screen.
        if (cam.WorldToViewportPoint(new Vector3(0, topEdge + movement, 0)).y < 1
            && cam.WorldToViewportPoint(new Vector3(0, bottomEdge + movement, 0)).y > 0)
        {
            return false;
        }

        return true;
    }

    private void RandomizeStart()
    {

        angle = Random.Range(0.1f, 2f);

        float rand = Random.Range(0f, 1f);
        if (rand < 0.5)
        {
            mirrorDirection = -1;
        }
        else
        {
            mirrorDirection = 1;
        }
        rand = Random.Range(0f, 1f);
        if (rand > 0.5)
        {
            movementDirection = -1;
        }
        else
        {
            movementDirection = 1;
        }
    }
}
