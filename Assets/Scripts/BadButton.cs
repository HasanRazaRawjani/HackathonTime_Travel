using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadButton : MonoBehaviour
{
    public void killPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.GetComponent<TimeTravel>().die();
        }
    }
}
