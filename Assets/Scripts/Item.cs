using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isBeingHeld;
    Rigidbody rb;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        isBeingHeld = false;
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Post"))
        {

        }
        else
        {
            if (this.CompareTag("Stickable") && !isBeingHeld)
            {
                rb.isKinematic = true;
                this.transform.parent = collision.transform;
                
                //rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
        
    }

    public void UnFreezeConstraints()
    {
        isBeingHeld = true;
        rb.constraints = RigidbodyConstraints.None;
    }
}
