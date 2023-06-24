using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;

    public float speed = 70f;

    public float explosionRadius = 0f;

    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    #region
    //    код представляє клас "Bullet" (куля) у грі.Основні функції, які він виконує:

    //Зберігає посилання на ціль, до якої направлена куля.
    //Зберігає посилання на об'єкт, який представляє візуальний ефект удару кулі.
    //Визначає швидкість руху кулі, радіус вибуху і кількість шкоди, яку куля завдає цілі.
    //Визначає метод "Seek", який встановлює ціль для кулі.
    //У методі "Update" куля рухається в напрямку цілі з заданою швидкістю. Якщо куля досягає цілі або перевищує відстань до неї, викликається метод "HitTarget".
    //У методі "HitTarget" відтворюється візуальний ефект удару кулі, наноситься шкода цілі, і якщо вказаний радіус вибуху більше нуля, куля вибухає, завдаючи шкоду всім ворогам у заданому радіусі.
    //Метод "Damage" наносить шкоду ворогу, використовуючи компонент "Enemy" у ворога.
    #endregion
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 4.7f);

        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
        else
        {
            Debug.LogError("Error");
        }
    }
}
