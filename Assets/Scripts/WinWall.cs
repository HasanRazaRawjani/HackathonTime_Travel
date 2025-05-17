using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{
    private SideUI sideUI;
    private GameObject player;
    private UI uI;

    void Start()
    {
        uI = GameObject.Find("CanvasUI").GetComponent<UI>();
        sideUI = GameObject.Find("CanvasUI").GetComponent<SideUI>();
        player = GameObject.Find("Player");

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<TimeTravel>().die();
            if (uI != null)
            {
                uI.ShowWinMenu();
            }
            else
            {
                sideUI.ShowWinMenu();
            }
            player.GetComponent<TimeTravel>().time = 0;
        }
    }
}
