using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed;
    GameObject target;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 vectorVel = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        rb.velocity = new Vector2 (vectorVel.x, vectorVel.y) * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
