using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpecialRed : MonoBehaviour
{
    public new Light light;

    void Start()
    {
        StartCoroutine(lights());
    }

    IEnumerator lights()
    {
        while (true)
        {
            GetComponent<Renderer>().material.color = Color.red;
            light.enabled = true;
            yield return new WaitForSeconds(4F);
            GetComponent<Renderer>().material.color = Color.black;
            light.enabled = false;
            yield return new WaitForSeconds(12F);
        }
    }
}
