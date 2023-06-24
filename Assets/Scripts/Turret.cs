using UnityEngine;

public class Turret : MonoBehaviour {

    [Header("General")]

    public float range = 15f;
    private Transform target;
    private Enemy targetEnemy;
    
    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab;
    private float fireCountdown = 0f;
    public float fireRate = 1f;

    [Header("Use Laser")]

    public bool useLaser;
    public int damageOverTime = 30;
    public float slowAmount = 0.5f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity setup fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 6.4f;
    public Transform firePoint;
    #region
    //    код відповідає за поведінку вежі в грі.Основні функції коду включають наступне:

    //Оголошуються змінні, такі як range(дальність атаки), target(ціль), bulletPrefab(префаб кулі), fireCountdown(затримка між пострілами), fireRate(швидкість вогню), useLaser(використання лазера) та інші.
    //Існує метод Start(), який запускається при старті гри та викликає метод UpdateTarget() з певною періодичністю.
    //Метод UpdateTarget() знаходить найближчого ворога всередині заданого радіусу і встановлює його як ціль для вежі.
    //У методі Update() перевіряється, чи є ціль, і викликаються відповідні методи для атаки цілі: LockOnTarget() для повороту вежі до цілі, Laser() для нанесення шкоди лазером або Shoot() для випуску кулі.
    //Метод LockOnTarget() повертає вежу в напрямок цілі шляхом плавного повороту.
    //Метод Laser() застосовує шкоду та ефект сповільнення до цілі лазером, а також відображає лінію лазеру, впливовий ефект та світло.
    //Метод Shoot() створює кулю і встановлює ціль для неї.
    //Метод OnDrawGizmosSelected() відображає сферу діапазону вежі у сцені для зручності редагування.
    //Отже, цей код відповідає за атаку ворогів з використанням вибраної стратегії (кулі або лазер) та поворот вежі в напрямку цілі.
    #endregion

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if(target == null)
        {
            if(useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                impactEffect.Stop();
                impactLight.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if(useLaser)
        {
            Laser();
        }
        else
        {
            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }
            
            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        impactEffect.transform.position = target.position + dir.normalized * 1.5f;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
