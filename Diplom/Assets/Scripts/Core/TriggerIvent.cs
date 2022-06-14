using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerIvent : MonoBehaviour
{
    public Object rabbit;
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Instantiate(rabbit,transform.position,transform.rotation);
        }
    }
}
