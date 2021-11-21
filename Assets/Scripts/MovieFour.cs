using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieFour : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    private float speed = 0.1f; //�������� �� ������

    private float maxSpeed = 0.5f; //������������ ��������
    private float minSpeed = 0.1f; //����������� ��������

    public List<GameObject> wheels; //����� ������
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = speed; //�������� �������� �����
        float sideSpeed = 0f; //�������� �������� ����

        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed; //�������� �� ���������� ������������ ��������
        }

        if (newSpeed < minSpeed)
        {
            newSpeed = minSpeed; //�������� �� ������� ������ ��������
        }

        transform.position = new Vector3(transform.position.x + 0.1f * sideSpeed, transform.position.y, transform.position.z - newSpeed);

        //if (control != null)
        //{
        //    control.sideSpeed = 0f; //����� ������� ��������
        //}

        if (wheels.Count > 0) //���� ���� �����
        {
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(-3f, 0f, 0f); //�������� ������� ������ �� ��� X
            }
        }
    }
}
