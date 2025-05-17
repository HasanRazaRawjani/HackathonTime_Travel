using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{
    private GameObject player;
    private UI uI;

    void Start()
    {
        uI = GameObject.Find("CanvasUI").GetComponent<UI>();
        player = GameObject.Find("Player");

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<TimeTravel>().die();
            uI.ShowWinMenu();
            player.GetComponent<TimeTravel>().time = 0;
        }
    }
}
