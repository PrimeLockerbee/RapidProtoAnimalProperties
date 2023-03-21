using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float destroyDistance = 1f;

    private Rigidbody2D rb;
    private Vector3 clickPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;

        clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (clickPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;

        if (Vector2.Distance(transform.position, clickPosition) < destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "IceBlock")
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
