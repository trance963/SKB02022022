using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed; // Скорость движения вперед и назад
    public float Sensitivity; // Скорость движения в стороны
    public float Jump; // Множитель прыжка
    public bool isGrounded; // проверка земли
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isGrounded = true; // проверяем на объекте ли мы
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W)) // Движения
        {
            rb.AddForce(0, 0, Speed * Time.deltaTime, ForceMode.VelocityChange);
            rb.GetComponent<Animator>().SetTrigger("Walk"); // состояние анимации ходьбы
        }

        if (Input.GetKey(KeyCode.D)) // Движения
        {
            rb.transform.position += rb.transform.right * Sensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) // Движения
        {
            rb.transform.position -= rb.transform.right * Sensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) // Движения
        {
            rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded) // Прыжок
        {
            rb.AddForce(transform.up * Jump, ForceMode.Impulse);
            isGrounded = false; // Прыгаем только от объектов
            rb.GetComponent<Animator>().SetTrigger("Idle");
        }

        if (Input.GetKey(KeyCode.Space)) // Анимация
        {
            rb.GetComponent<Animator>().SetTrigger("Jump");
        }

        else rb.GetComponent<Animator>().SetTrigger("Idle");
    }
}
