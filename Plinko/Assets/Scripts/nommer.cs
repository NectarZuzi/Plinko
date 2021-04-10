using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nommer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        Destroy(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        Destroy(collision.gameObject);
    }
}
