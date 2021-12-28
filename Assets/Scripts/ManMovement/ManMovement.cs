using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    private float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightTurnForMan"))
        {
            transform.Rotate(0, 90, 0);
        }
    }
}
