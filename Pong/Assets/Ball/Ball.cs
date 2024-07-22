using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private float randomStartAngle;
    private int mirrorDirection;
    private int movementDirection;

    void Start()
    {
        randomStartAngle = Random.Range(0.1f, 2f);

        float rand = Random.Range(0f, 1f);
        if(rand < 0.5)
        {
            mirrorDirection = -1;
        } else
        {
            mirrorDirection = 1;
        }
        rand = Random.Range(0f, 1f);
        if(rand > 0.5)
        {
            movementDirection = -1;
        } else
        {
            movementDirection = 1;
        }
    }

    void Update()
    {

        transform.position += new Vector3(speed * randomStartAngle * mirrorDirection * movementDirection * Time.deltaTime, speed * Time.deltaTime * movementDirection, 0);

    }
}
