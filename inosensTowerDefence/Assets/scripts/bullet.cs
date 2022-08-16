using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * 6;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.damage();
            Destroy(gameObject);
        }
    }
  
    
}
