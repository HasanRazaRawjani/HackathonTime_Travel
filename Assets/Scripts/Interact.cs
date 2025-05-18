using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    private AudioSource ButtonPress;
    private Rigidbody rb;
    private GameObject cam;
    public float interactDistance = 3f;
    public GameObject UIInteractactText;

    void Start()
    {
        ButtonPress = GameObject.Find("MusicController").transform.Find("ButtonPress").GetComponent<AudioSource>();
        UIInteractactText.SetActive(false);
        rb = GetComponent<Rigidbody>();    
        cam = gameObject.transform.Find("Main Camera").gameObject;
    }

    void Update()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                UIInteractactText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                    if (hit.collider.gameObject.name == "RightButton")
                    {
                        if (!ButtonPress.isPlaying)
                        {
                            ButtonPress.Play();
                        }
                        hit.collider.gameObject.GetComponent<Animator>().SetTrigger("isClicked");
                        if (hit.collider.gameObject.GetComponent<RightButton>() != null)
                        {
                            hit.collider.gameObject.GetComponent<RightButton>().activateLazer();
                        } else
                        {
                            hit.collider.gameObject.GetComponent<GateDroppingFinalScript>().activateLazer();
                        }
                    }
                    
                    if (hit.collider.gameObject.name == "Button")
                    {
                        hit.collider.gameObject.GetComponent<BadButton>().killPlayer();
                    }

                }

            } else
            {
                UIInteractactText.SetActive(false);
            }
        }
    }
}
