using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public float speed;
    public Rigidbody2D rb;
    public Boundary boundary;
    public GameObject explosionAnimation;

    private void Start()
    {
        GameController.instance.isPlayerActive = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector2( Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax) );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionAnimation, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameController.instance.isPlayerActive = false;
        }
    }
}
