using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Шар
    public float leftBoundary = 0.3f; // Левый порог (в долях экрана)
    public float rightBoundary = 0.7f; // Правый порог (в долях экрана)
    public float maxCameraSpeed = 10f;
    public float boundaryTolerance = 0.05f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 viewportPos = cam.WorldToViewportPoint(target.position);
        float moveDirection = 0f;
        float speedFactor = 0f;

        if (viewportPos.x < leftBoundary)
        {
            // Чем дальше влево - тем больше скорость
            speedFactor = (leftBoundary - viewportPos.x) / boundaryTolerance;
            moveDirection = -1f;
        }
        else if (viewportPos.x > rightBoundary)
        {
            // Чем дальше вправо - тем больше скорость
            speedFactor = (viewportPos.x - rightBoundary) / boundaryTolerance;
            moveDirection = 1f;
        }

        // Ограничим скорость, чтобы не улетала в космос
        speedFactor = Mathf.Clamp(speedFactor, 0f, 1f);

        // Двигаем камеру
        transform.position += Vector3.right * moveDirection * maxCameraSpeed * speedFactor * Time.deltaTime;
    }
}
