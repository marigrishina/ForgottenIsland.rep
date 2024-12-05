using UnityEngine;

public class Stone : MonoBehaviour
{
    public string color; // Цвет камушка (blue, green, orange, purple)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StoneStand"))
        {
            StoneStand stand = other.GetComponent<StoneStand>();
            if (stand != null && stand.color == color)
            {
                // Успех: камушек помещен на стенд правильного цвета
                Debug.Log($"{color} stone placed on {stand.color} stand!");
                // Фиксируем камушек, например, отключаем его физику
                GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                Debug.Log($"Wrong stand! {color} stone can't be placed on {stand.color} stand.");
            }
        }
    }
}

public class StoneStand : MonoBehaviour
{
    public string color; // Цвет стенда (blue, green, orange, purple)

    private void Start()
    {
        // Убедитесь, что цвет стенда задан, например, через инспектор
        if (string.IsNullOrEmpty(color))
        {
            Debug.LogError("Stand color is not set!");
        }
    }
}