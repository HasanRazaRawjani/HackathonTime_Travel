using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    public GameObject Lazer;
    public void activateLazer()
    {
        Lazer.SetActive(false);
    }
}
