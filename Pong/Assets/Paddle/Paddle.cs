using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private SpriteRenderer spriteRenderer;
    private Camera cam = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<Camera>();

    }

    void Update()
    {
        
        float movement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if(!checkForBorderCollision(movement))
        {
            transform.position += new Vector3(0, movement, 0);
        }

    }

    private bool checkForBorderCollision(float movement)
    {
        // Get the height of the sprite and multiply it by the scale on the Y axis.
        float paddleHeight = spriteRenderer.sprite.bounds.size.y * transform.lossyScale.y;

        float topEdge = transform.position.y + paddleHeight / 2;
        float bottomEdge = transform.position.y - paddleHeight / 2;

        // Check if topEdge will go over the screen or if bottomEdge will go under the screen.
        if (cam.WorldToViewportPoint(new Vector3(0, topEdge + movement, 0)).y < 1
            && cam.WorldToViewportPoint(new Vector3(0, bottomEdge + movement, 0)).y > 0)
        {
            return false;
        }

        return true;
    }
}
