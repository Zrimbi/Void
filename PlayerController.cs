using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;            // Скорость движения
    public float turnSmoothTime = 0.1f;   // Время сглаживания поворота
    private float turnSmoothVelocity;      // Скорость сглаживания поворота
    public Transform cameraTransform;      // Ссылка на Transform камеры

    private Rigidbody rb;               // Ссылка на Rigidbody
    public bool isGrounded;             // Находится ли персонаж на земле
    public static char walk = 'B';
    public static int hungry = 4;
    public int timerHungry = 0;
    public int healPoints = 100;
    private int timerHeal = 0;
    public Canvas backpack;

    public TMP_Text hpText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Заморозка вращения, чтобы предотвратить падение
        rb.freezeRotation = true;
    }

    void Update()
    {
        timerHungry += 1;
        timerHeal += 1;
        // Получение ввода
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Движение
        if (direction.magnitude >= 0.1f && backpack.enabled == false)
        {
            // Вычисление угла поворота
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Перемещение персонажа
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 movement = moveDir.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);  // Использование MovePosition для физики

            walk = 'W';
        }
        else
        {
            walk = 'I';
        }

        if (direction.magnitude >= 0.1f && Input.GetKey(KeyCode.LeftShift) && hungry > 1 && backpack.enabled == false)
        {
            speed = 6f;
            walk = 'R';
            timerHungry += 15;
        }
        else
        {
            speed = 3f;
        }

        if (timerHungry > 100000)
        {
            timerHungry = 0;
            hungry -= 1;
        }

        Backpack();

        hpText.text = Mathf.Ceil(healPoints) + "%";

        if (hungry < 1 && timerHeal / 60 > 5)
        {
            healPoints -= 1;
            timerHeal = 0;
        }
    }

    // Функция для проверки, находится ли персонаж на земле (используем OnCollisionStay)
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") // Проверяем, что столкнулись с землей
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void Backpack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            backpack.enabled = !backpack.enabled;
        }
    }
}
