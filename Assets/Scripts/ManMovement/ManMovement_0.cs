using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovement_0 : MonoBehaviour
{
    public Rigidbody rb;
    private float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftTurnForMan"))
        {
            transform.Rotate(0, 270, 0);
        }
    }
}
