using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float startHealth = 100f;
    private float health;
    public int worth = 50;

    public GameObject deathEffect;

    public Image healthbar;

    private bool isDead = false;

    #region
    //    код відповідає за логіку ворогів в грі.Основні функції, які він виконує:

    //Визначає початкову швидкість ворога(startSpeed) і зберігає поточну швидкість(speed) у внутрішній змінній.
    //Визначає початкове здоров'я ворога (startHealth) і зберігає поточне здоров'я(health) у внутрішній змінній.
    //Визначає вартість ворога(worth) - кількість грошей, яку гравець отримує за його знищення.
    //Відтворює ефект смерті ворога(deathEffect) при його знищенні.
    //Використовує прогресбар(healthbar) для відображення поточного здоров'я ворога.
    //Метод "Start" встановлює початкові значення швидкості та здоров'я ворога.
    //Метод "TakeDamage" зменшує здоров'я ворога на певну кількість (amount) та оновлює відображення прогресбару. Якщо здоров'я стає менше або рівне нулю, викликається метод "Die".
    //Метод "Slow" зменшує швидкість ворога на певний відсоток(amount) від початкової швидкості.
    //Метод "Die" викликається, коли ворог помере.Він збільшує кількість грошей гравця(PlayerStats.money) на вартість ворога(worth), відтворює ефект смерті та зменшує лічильник живих ворогів(WaveSpawner.enemiesAlive). Нарешті, ворог знищується(Destroy).
    #endregion
    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthbar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.money += worth;

        GameObject deathParticles = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticles, 2.31f);

        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}
