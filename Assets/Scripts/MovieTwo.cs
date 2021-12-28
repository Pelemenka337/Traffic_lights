using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTwo : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    private float speed = 25f; //Скорость на старте

    public LightSpecialGreen Light_First;

    public bool IsOnTrigger = false;

    public int rotat = 0;
    public bool check = false;

    private float maxSpeed = 35f; //Максимальная скорость
    private float minSpeed = 25f; //Минимальная скорость
    public bool IsRotate = false;

    public List<GameObject> wheels; //Колёса машины
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = Random.Range(25f, 35f);  //Скорость движения вперёд

        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed; //Проверка на превышение максимальной скорости
        }

        if (newSpeed < minSpeed)
        {
            newSpeed = minSpeed; //Проверка на слишком низкую скорость
        }

        if (!IsOnTrigger)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * newSpeed);
        }
        if (IsRotate)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 75f);
        }

        if (wheels.Count > 0) //Если есть колёса
        {
            foreach (var wheel in wheels)
            {
                wheel.transform.Rotate(-3f, 0f, 0f); //Вращение каждого колеса по оси X
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (check == false && other.CompareTag("Right_Third"))
        {
            rotat = Rot();
            check = true;
            if (rotat == 2)
            {
                IsRotate = true;
            }
        }
        if ((other.CompareTag("Traf_Light") || other.CompareTag("Back")) && other.transform.position.x < transform.position.x)
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
