using UnityEngine;

// дозволяє визначити характеристики кожної хвилі ворогів, такі як тип ворога, кількість і швидкість їх з'явлення. Використовується для створення хвиль ворогів під час гри.
[System.Serializable]
public class Wave {
    public GameObject enemy;
    public int count;
    public float rate;
}
