using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{   
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
