using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour {

    public int healtPoints;
    public GameObject explosion;

    private void Update()
    {
        if (healtPoints == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            StartCoroutine(ChangeAlpha());
            healtPoints--;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator ChangeAlpha()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.01f);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
