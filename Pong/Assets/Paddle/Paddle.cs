using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private SpriteRenderer spriteRenderer;
    private float paddleHeight;

    private Camera cam = null;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<Camera>();

        // Get the height of the sprite and multiply it by the scale on the Y axis.
        paddleHeight = spriteRenderer.sprite.bounds.size.y * transform.lossyScale.y;
    }

    void Update()
    {
        float topEdge = transform.position.y + paddleHeight / 2;
        float bottomEdge = transform.position.y - paddleHeight / 2;

        float movement = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        // Check if topEdge will go over the screen or if bottomEdge will go under the screen.
        if(cam.WorldToViewportPoint(new Vector3(0, topEdge + movement, 0)).y < 1
            && cam.WorldToViewportPoint(new Vector3(0, bottomEdge + movement, 0)).y > 0)
        {
            transform.position += new Vector3(0, movement, 0);
        }
    }
}
