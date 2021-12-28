using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    public LightSpecialGreen Light_First;

    public bool IsOnTrigger = false;

    public int rotat = 0;
    public bool check = false;

    private float speed = 25f; //�������� �� ������

    private float maxSpeed = 35f; //������������ ��������
    private float minSpeed = 25f; //����������� ��������

    public List<GameObject> wheels; //����� ������
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        float newSpeed = Random.Range(25f,35f); //�������� �������� �����

        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed; //�������� �� ���������� ������������ ��������
        }

        if (newSpeed < minSpeed)
        {
            newSpeed = minSpeed; //�������� �� ������� ������ ��������
        }



        if (!IsOnTrigger) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * newSpeed);
        }

        if (wheels.Count > 0) //���� ���� �����
        {
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(-3f, 0f, 0f); //�������� ������� ������ �� ��� X
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (check == false && other.CompareTag("Right_First"))
        {
            rotat = Rot();
            check = true;
            if (rotat == 2)
            {
                transform.Rotate(0, 90, 0);
            }
        }
        if ((other.CompareTag("Traf_Light") || other.CompareTag("Back")) && other.transform.position.x > transform.position.x) 
        {
            Debug.Log(other.gameObject.name);
            IsOnTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Traf_Light") || other.CompareTag("Back"))
        {
            Debug.Log(other.gameObject.name);
            IsOnTrigger = false;
        }
    }
    public int Rot()
    {
        return Random.Range(1, 5);
    }
}
