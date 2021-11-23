using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpecialGreen : MonoBehaviour
{
    public new Light light;
    public bool isgreenfirst;

    public BoxCollider Box_First;

    public Vector3 first_position;
    void Start()
    {
        first_position = Box_First.center;
        StartCoroutine(lights());
    }

    IEnumerator lights()
    {
        GetComponent<Renderer>().material.color = Color.black;
        isgreenfirst = false;
        Box_First.center = first_position;
        light.enabled = false;
        yield return new WaitForSeconds(8F);
        while (true)
        {
            GetComponent<Renderer>().material.color = Color.green;
            isgreenfirst = true;
            Box_First.center = Vector3.up * 9999;
            light.enabled = true;
            yield return new WaitForSeconds(4F);
            GetComponent<Renderer>().material.color = Color.black;
            isgreenfirst = false;
            Box_First.center = first_position;
            light.enabled = false;
            yield return new WaitForSeconds(12F);
        }
    }
}
