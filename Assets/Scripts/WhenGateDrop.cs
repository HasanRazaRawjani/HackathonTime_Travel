using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenGateDrop : MonoBehaviour
{
    private AudioSource GateDrop;
    private AudioSource bombs;
    private GameObject ghost;
    private GameObject bombsSpawn;

    void Awake()
    {
        bombsSpawn = GameObject.Find("Bombs");
        bombsSpawn.SetActive(false);
    }

    void Start()
    {
        GateDrop = GameObject.Find("MusicController").transform.Find("GateDrop").GetComponent<AudioSource>();
        bombs = GameObject.Find("MusicController").transform.Find("ExplosionSound").GetComponent<AudioSource>();
        ghost = GameObject.Find("Level-3").transform.Find("Enviourment").transform.Find("Time Keeper").gameObject;
    }
    void OnCollisionEnter(Collision collision)
    {
        GateDrop.Play();
        bombs.Play();
        bombsSpawn.SetActive(true);
        ghost.SetActive(false);

    }
}
