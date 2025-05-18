using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    private AudioSource TurretShhootSound;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 20f;

    private float fireTimer = 0f;

    void Start()
    {
        TurretShhootSound = GameObject.Find("MusicController").transform.Find("TurretSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= 1f / fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        if(!TurretShhootSound.isPlaying)
        {
            TurretShhootSound.Play();
        }
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (bullet.GetComponent<Rigidbody>() != null)
        {
            bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * bulletSpeed;
        }
    Destroy(bullet, 10f);
    }
}