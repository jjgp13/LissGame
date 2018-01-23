using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb.velocity = Vector2.up * speed;
    }

}
