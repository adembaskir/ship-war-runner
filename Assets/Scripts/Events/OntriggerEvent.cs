using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OntriggerEvent : MonoBehaviour
{
    [Header("Player Trigger Event")]
    public UnityEvent playerOnEnter;
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            playerOnEnter?.Invoke();
            
        }
    }
  


}
