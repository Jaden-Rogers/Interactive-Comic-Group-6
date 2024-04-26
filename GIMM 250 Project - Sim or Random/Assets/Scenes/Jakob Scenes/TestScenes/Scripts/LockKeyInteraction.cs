using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyLockInteraction : MonoBehaviour
{
    [SerializeField] private GameObject key; // Reference to the key GameObject

    void Start()
    {
        key = GameObject.Find("Key");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lock"))
        {
            key.SetActive(false) ;
            Destroy(other.gameObject);
        }
        
    }
}

  





