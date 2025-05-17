using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public GameObject PlayerSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TimeTravelToSpawn();
        }
    }

    void TimeTravelToSpawn()
    {
        gameObject.transform.position = PlayerSpawn.transform.position; 
        gameObject.transform.rotation = PlayerSpawn.transform.rotation; 
    }

}
