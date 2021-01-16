using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float bulletSpeed = 3f;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    [SerializeField] private bool canShoot;
    private float fireRate = 1f;
    [SerializeField] private float timer = 0f;

    private void Update()
    {
        if(canShoot == false)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                timer = 0f;
                canShoot = true;
            }
        }
    }
    public void Shooting(GameObject target)
    {
        Vector3 difference = target.transform.position - transform.position;
        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();
        if (canShoot)
        {
            FireBullet(direction);
            canShoot = false;
        }
    }

    void FireBullet(Vector2 direction)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = bulletStart.transform.rotation;
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
