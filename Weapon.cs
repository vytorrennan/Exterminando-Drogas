using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    private float count = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 0)
        {
            count -= 1 * Time.deltaTime;
        }
        if (Input.GetButton("Fire1") && count <= 0f)
        {
            Shoot();
            count = 0.25f;
        }
    }

    private void Shoot()
    {
        Vector3 variation = new Vector3(0f, Random.Range(-0.3f, 0.3f), 0);
        Instantiate(bulletPrefab, firePoint.position + variation, firePoint.rotation);
    }


}
