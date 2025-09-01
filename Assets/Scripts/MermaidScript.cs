using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidScript : MonoBehaviour
{
    public SpriteRenderer merRenderer;
    public Sprite upMermaid;
    public Sprite downMermaid;

    public PolygonCollider2D upCollider;
    public PolygonCollider2D downCollider;

    public Rigidbody2D rigidBody;
    public float boost = 10f;

    public LogicScript logic;

    public bool alive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        merRenderer.sprite = downMermaid;

        downCollider.enabled = true;
        upCollider.enabled = false;

        alive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidBody.linearVelocityY > 0)
        {
            merRenderer.sprite = upMermaid;
            downCollider.enabled = false;
            upCollider.enabled = true;
        } else
        {
            merRenderer.sprite = downMermaid;
            downCollider.enabled = true;
            upCollider.enabled = false;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true) && alive)
        {
            rigidBody.linearVelocity = Vector2.up * boost;
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) == true) && alive)
        {
            rigidBody.linearVelocity = Vector2.down * boost;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.loadGameOverScreen();
        alive = false;
    }
}
