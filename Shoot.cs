using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Shoot(Clone)" && collision.name != "slopesDetection")
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
    }


}
