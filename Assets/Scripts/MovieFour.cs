using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieFour : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject car;

    private float speed = 0.1f; //Скорость на старте

    private float maxSpeed = 0.5f; //Максимальная скорость
    private float minSpeed = 0.1f; //Минимальная скорость

    public List<GameObject> wheels; //Колёса машины
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = speed; //Скорость движения вперёд
        float sideSpeed = 0f; //Скорость движения вбок

        if (newSpeed > maxSpeed)
        {
            newSpeed = maxSpeed; //Проверка на превышение максимальной скорости
        }

        if (newSpeed < minSpeed)
        {
            newSpeed = minSpeed; //Проверка на слишком низкую скорость
        }

        transform.position = new Vector3(transform.position.x + 0.1f * sideSpeed, transform.position.y, transform.position.z - newSpeed);

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
}
