using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource walkSound;
    
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded;

    public float groundCheckDistance = 0.2f;
    public LayerMask groundMask;
    public Transform cameraTransform; 

    void Start()
    {
        walkSound = GameObject.Find("MusicController").transform.Find("WalkingSound").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        
            Vector3 horizontalVelocity = rb.velocity;
            horizontalVelocity.y = 0f;
            bool isWalking = horizontalVelocity.magnitude > 0.1f;


            if (isWalking)
            {
                if (!walkSound.isPlaying)
                {
                    walkSound.Play();
                }
                Debug.Log("Player is walking");
            }



            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 move = (forward * moveZ + right * moveX).normalized;
            Vector3 newVelocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
            rb.velocity = newVelocity;

            isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            Vector3 camForward = cameraTransform.forward;
            camForward.y = 0f;
            if (camForward.sqrMagnitude > 0.01f)
                transform.forward = camForward;
    }



}
