using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed; // Speed given to attached object
    public Rigidbody2D rb; // Reference to the Rigidbody component, attached to the GameObject
    private Vector2 moveInput; // Vector to store input for movement

    [SerializeField] private AudioClip ratSound;
    [SerializeField] private AudioClip toiletFlush;
    [SerializeField] private AudioClip Handcuffs;
    [SerializeField] private AudioClip Toothbrush;
    private AudioSource audioSource;

    [SerializeField] private GameObject key; // Reference to the key GameObject

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //MOVEMENT CODE 

    void Update()
    {
        // Get the horizontal and vertical input from the player, left right up down keys
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement vector to ensure consistent speed in all directions
        moveInput.Normalize();

        // Set the velocity of the Rigidbody to move the object in the desired direction
        // Multiplied by the speed to control actual movement speed of attached object
        rb.velocity = moveInput * speed;

        // Update the position of the key if it is a child of the player
        if (key.transform.parent == transform)
        {
            key.transform.localPosition = Vector3.zero; // Set key's local position to zero relative to the player
      
        }
    }

    //SOUND EFFECT CODE

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("TP"))
        {
            if (ratSound != null && audioSource != null)
            {
                audioSource.clip = toiletFlush;
                audioSource.Play();
            }
        }
        if (other.CompareTag("Rat"))
        {
            if (ratSound != null && audioSource != null)
            {
                audioSource.clip = ratSound;
                audioSource.Play();
            }
        }
        if (other.CompareTag("Handcuffs"))
        {
            if (ratSound != null && audioSource != null)
            {
                audioSource.clip = Handcuffs;
                audioSource.Play();
            }
        }
        if (other.CompareTag("Toothbrush"))
        {
            if (ratSound != null && audioSource != null)
            {
                audioSource.clip = Toothbrush;
                audioSource.Play();
            }
        }
        
        if (other.gameObject == key)
        {
            key.transform.parent = transform;
        }
    }
}
