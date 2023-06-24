using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;

    #region
    //    код відповідає за рух ворогів в грі.Основні функції, які він виконує:

    //Визначає змінні для збереження поточної цілі(target) та індексу поточного вузла шляху(waypointIndex).
    //Отримує посилання на компонент Enemy, приєднаний до цього об'єкта.
    //У методі Start встановлює початкову ціль для ворога, якою є перший вузол шляху з масиву Waypoints.points.
    //У методі Update відбувається рух ворога.Ворог пересувається у напрямку цілі зі швидкістю enemy.speed за допомогою методу Translate.Якщо відстань між ворогом та ціллю менша або дорівнює 0.27f, викликається метод GetNextWaypoint для отримання наступного вузла шляху.
    //У методі GetNextWaypoint перевіряється, чи досягнуто останнього вузла шляху.Якщо так, викликається метод EndPath для обробки завершення шляху.В іншому випадку оновлюється ціль ворога на наступний вузол шляху.
    //У методі EndPath зменшується кількість залишених життів гравця (PlayerStats.lives), зменшується лічильник живих ворогів (WaveSpawner.enemiesAlive) та знищується об'єкт ворога (Destroy(gameObject)).
    //Отже, цей код контролює рух ворогів по заданому шляху, визначеному масивом вузлів, та взаємодіє з іншими компонентами гри для обробки ситуацій, таких як досягнення кінця шляху та вплив на життя гравця.
    #endregion
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.27f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
