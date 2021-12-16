using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieFour : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    public LightSpecialGreen Light_First;

    public bool IsOnTrigger = false;

    private float speed = 0.2f; //�������� �� ������

    private float maxSpeed = 0.6f; //������������ ��������
    private float minSpeed = 0.1f; //����������� ��������

    public List<GameObject> wheels; //����� ������
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = Random.Range(0.3f, 0.6f);  //�������� �������� �����
        float sideSpeed = 0f; //�������� �������� ����

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
            transform.Translate(new Vector3(0f, 0f, 75f * Time.deltaTime * newSpeed));
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
        if (!other.CompareTag("Destr") && other.transform.position.z < transform.position.z)
        {
            Debug.Log(other.gameObject.name);
            IsOnTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Destr"))
        {
            Debug.Log(other.gameObject.name);
            IsOnTrigger = false;
        }
    }
}
