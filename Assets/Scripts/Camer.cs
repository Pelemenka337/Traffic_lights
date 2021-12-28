using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer : MonoBehaviour
{
    private Camera cam1;
    public Camera cam2;
    public Camera cam3;
    private int count = 2;
    // Start is called before the first frame update
    void Start()
    {
        cam1 = GetComponent<Camera>();
        cam1 = Camera.main;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            count++;
        }
        if (count == 0)
        {
            cam1.enabled = true;
            cam2.enabled = false;
            cam3.enabled = false;
        }
        if (count == 1)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
        }
        if (count == 2)
        {
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
        }
        if (count > 2)
        {
            count = 0;
        }
    }
}
