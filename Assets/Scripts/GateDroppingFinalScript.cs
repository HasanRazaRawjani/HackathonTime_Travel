using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDroppingFinalScript : MonoBehaviour
{
    public GameObject Lazer;
    public void activateLazer()
    {
        Lazer.GetComponent<Rigidbody>().useGravity = true;
    }
}