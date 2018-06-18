using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    public enum movePatterns {Points, SideToSide, DirectToPlayer};
    public movePatterns movements;
    public float speed;
    public Vector2[] points;
    private Vector2 currentPoint;
    private int index;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        index = 0;
        currentPoint = points[index];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}

    private void MoveWithPoints()
    {
        Vector2 dir = currentPoint - rb.position;

        if (Mathf.Abs(dir.x) < 0.1f && Mathf.Abs(dir.y) < 0.1f)
        {
            if (index == points.Length - 1)
                index = 0;
            else
                index++;

            currentPoint = points[index];
        }

        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }

    private void MoveSideToSide()
    {

    }
}
