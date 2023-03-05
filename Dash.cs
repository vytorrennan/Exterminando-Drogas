using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dash2();
    }

    private void Dash2()
    {
        bool dashPressed = Input.GetButtonDown("Fire3");


        if (dashPressed)
        {
            rb.AddForce(new Vector2(250000 * Time.deltaTime, rb.velocity.y));
        }
    }
}
