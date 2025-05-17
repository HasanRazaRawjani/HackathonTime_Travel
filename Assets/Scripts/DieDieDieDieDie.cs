using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieDieDieDieDie : MonoBehaviour
{
    private TimeTravel timeTravel;

    void Start()
    {
        timeTravel = GetComponent<TimeTravel>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            timeTravel.die();
        }
    }
}
