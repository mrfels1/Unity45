using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 10f); // Уничтожить этот объект через 10 секунд
    }
}
