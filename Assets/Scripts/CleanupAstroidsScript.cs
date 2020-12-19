using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupAstroidsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log ("Collision happened");
        // Debug.Log(other.transform.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy (other.gameObject, 0);
    }
}
