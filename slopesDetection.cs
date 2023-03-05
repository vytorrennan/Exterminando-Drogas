using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slopesDetection : MonoBehaviour
{

    [SerializeField] private GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            if (collision.transform.rotation.z > 0 && player.gameObject.GetComponent<Movemment>().side == -1)
            {
                player.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (collision.transform.rotation.z < 0 && player.gameObject.GetComponent<Movemment>().side == 1)
            {
                player.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (collision.transform.rotation.z < 0 && player.gameObject.GetComponent<Movemment>().side == -1)
            {
                player.gameObject.GetComponent<Movemment>().slope = true;
            }
            if (collision.transform.rotation.z > 0 && player.gameObject.GetComponent<Movemment>().side == 1)
            {
                player.gameObject.GetComponent<Movemment>().slope = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            if (collision.transform.rotation.z > 0 && player.gameObject.GetComponent<Movemment>().side == -1)
            {
                player.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (collision.transform.rotation.z < 0 && player.gameObject.GetComponent<Movemment>().side == 1)
            {
                player.gameObject.GetComponent<Movemment>().slope = false;
            }
            if (collision.transform.rotation.z < 0 && player.gameObject.GetComponent<Movemment>().side == -1)
            {
                player.gameObject.GetComponent<Movemment>().slope = true;
            }
            if (collision.transform.rotation.z > 0 && player.gameObject.GetComponent<Movemment>().side == 1)
            {
                player.gameObject.GetComponent<Movemment>().slope = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slope"))
        {
            player.gameObject.GetComponent<Movemment>().slope = false;
            //player.gameObject.GetComponent<Movemment>().slopeJump = false;
        }
    }
}
