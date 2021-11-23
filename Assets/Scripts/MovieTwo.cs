using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTwo : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    private float speed = 0.2f; //Скорость на старте

    public LightSpecialGreen Light_First;

    public bool IsOnTrigger = false;

    private float maxSpeed = 0.6f; //Максимальная скорость
    private float minSpeed = 0.1f; //Минимальная скорость

    public List<GameObject> wheels; //Колёса машины
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = Random.Range(0.3f, 0.6f);  //Скорость движения вперёд
        float sideSpeed = 0f; //Скорость движения вбок

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
            //transform.position = new Vector3(transform.position.x - newSpeed, transform.position.y, transform.position.z + 0.1f * sideSpeed);
            transform.Translate(new Vector3(0f, 0f, 75f * Time.deltaTime * newSpeed));
        }

        //if (control != null)
        //{
        //    control.sideSpeed = 0f; //Сброс боковой скорости
        //}

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
        if (!other.CompareTag("Destr") && other.transform.position.x < transform.position.x)
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
