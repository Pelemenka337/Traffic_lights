using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTurn : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Man"))
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
