using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopesGroundCheck : MonoBehaviour
{

    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform PlayerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GroundCheckMethod();
    }

    private void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 50f, layerMask);
        if (Hit2D != false && Hit2D.collider.gameObject.CompareTag("Slope"))
        {
            Vector2 temp = PlayerFeet.position;
            temp.y = Hit2D.point.y;
            PlayerFeet.position = temp;
            if (Hit2D.collider.transform.rotation.z > 0 && this.gameObject.GetComponent<Movemment>().side == -1)
            {
                this.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (Hit2D.collider.transform.rotation.z < 0 && this.gameObject.GetComponent<Movemment>().side == 1)
            {
                this.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (Hit2D.collider.transform.rotation.z < 0 && this.gameObject.GetComponent<Movemment>().side == -1)
            {
                this.gameObject.GetComponent<Movemment>().slope = true;
            }
            if (Hit2D.collider.transform.rotation.z > 0 && this.gameObject.GetComponent<Movemment>().side == 1)
            {
                this.gameObject.GetComponent<Movemment>().slope = true;
            }
            //this.gameObject.GetComponent<Movemment>().slope = true;
            this.gameObject.GetComponent<Movemment>().slopeJump = true;
        }
        else
        {
            this.gameObject.GetComponent<Movemment>().slopeJump = false;
        }
    }
}
