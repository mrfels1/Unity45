using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "Level/Spawn Settings", order = 1)]
public class SpawnSettings : ScriptableObject
{
    public GameObject prefab;       // Префаб для спавна
    public Vector3 spawnOffset;      // Смещение относительно точки спавна
    public Vector3 randomRotationMin;
    public Vector3 randomRotationMax;     // Максимальная случайная ротация по осям
    public Vector3 randomPositionMin;
    public Vector3 randomPositionMax;     // Максимальная случайная позиция по осям
}
