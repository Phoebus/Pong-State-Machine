using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    private float timer = 2;
    private float time = 0;

    private SpriteRenderer spriteRenderer;
    private float width;

    private Camera cam = null;
    private Vector3 posFromBorder;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<Camera>();

        width = spriteRenderer.sprite.bounds.size.y * transform.lossyScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        float topEdge = transform.position.y + width / 2;
        float bottomEdge = transform.position.y - width / 2;

        posFromBorder = cam.WorldToViewportPoint(new Vector3(transform.position.x, topEdge, transform.position.z));

        Vector3 movement = new Vector3(0, Input.GetAxisRaw("Vertical"), 0) * speed * Time.deltaTime;
        transform.position += movement;

        time += Time.deltaTime;
        if(time > timer)
        {
            Debug.Log(posFromBorder);
            time = 0;
        }
    }
}
