using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public SpawnSettings[] spawnableObjects; // Массив настроек спавна
    public Transform player;
    public float spawnDistance = 20f;
    public float spawnInterval = 5f;

    private float nextSpawnX = 0f;

    void Start()
    {
        nextSpawnX = player.position.x + spawnDistance;
    }

    void Update()
    {
        if (player.position.x + spawnDistance > nextSpawnX)
        {
            SpawnObstacle(nextSpawnX);
            nextSpawnX += spawnInterval;
        }
    }

    void SpawnObstacle(float xPosition)
    {

        SpawnSettings settings = spawnableObjects[Random.Range(0, spawnableObjects.Length)];

        Vector3 basePosition = new Vector3(xPosition, 0f, 0f);
        Vector3 spawnPosition = basePosition + settings.spawnOffset;

        // Добавим случайное смещение (если указано)
        spawnPosition += new Vector3(
            Random.Range(settings.randomPositionMin.x, settings.randomPositionMax.x),
            Random.Range(settings.randomPositionMin.y, settings.randomPositionMax.y),
            Random.Range(settings.randomPositionMin.z, settings.randomPositionMax.z)
        );

        Quaternion spawnRotation = Quaternion.Euler(
            Random.Range(settings.randomRotationMin.x, settings.randomRotationMax.x),
            Random.Range(settings.randomRotationMin.y, settings.randomRotationMax.y),
            Random.Range(settings.randomRotationMin.z, settings.randomRotationMax.z)
        );

        Instantiate(settings.prefab, spawnPosition, spawnRotation);
    }
}