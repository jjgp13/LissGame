using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;
    public GameObject player;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        rb.velocity = new Vector2 (playerPosition.x, playerPosition.y) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
