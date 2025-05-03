using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;        // Скорость масштабирования
    public float minDistance = 2f;       // Минимальное расстояние до цели
    public float maxDistance = 10f;      // Максимальное расстояние до цели
    public Transform target;           // Объект, вокруг которого вращается камера (цель)

    private float currentDistance;    // Текущее расстояние до цели

    void Start()
    {
        // Инициализируем текущее расстояние
        if (target != null) {
            currentDistance = Vector3.Distance(transform.position, target.position);
        } else {
             Debug.LogError("Целевой объект не установлен! Перетащите цель в поле Target.");
        }

        //Ограничиваем расстояние
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
    }

    void Update()
    {
        // Получаем ввод от колесика мыши
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");

        // Изменяем расстояние
        currentDistance -= scrollDelta * zoomSpeed;

        // Ограничиваем расстояние в пределах minDistance и maxDistance
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);

        // Обновляем позицию камеры
        if (target != null)
        {
            Vector3 direction = (transform.position - target.position).normalized;
            transform.position = target.position + direction * currentDistance;
        }
        else
        {
            Debug.LogWarning("Цель не найдена!");
        }
    }
}
