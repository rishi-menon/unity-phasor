using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMovementScript : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    
    float speed;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = (Vector2)(transform.position);
        pos.x -= 4 * Time.deltaTime;

        rbody.MovePosition (pos);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log ("Collision happened here");
        // Debug.Log(other.transform.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log ("Collision happened here");
        // Debug.Log(other.transform.name);
    }

}
