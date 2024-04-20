using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyLockInteraction : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lock"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
}

  





