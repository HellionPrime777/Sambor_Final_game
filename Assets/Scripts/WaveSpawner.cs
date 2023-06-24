using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public static int enemiesAlive = 0;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5.5f;

    private float countdown = 6.5f;

    [SerializeField]
    private Text waveCountdownTimer;

    private int waveIndex = 0;
    #region
    //    код реалізує логіку спавну хвиль ворогів в грі.Основні елементи коду включають наступне:

    //gameManager: посилання на об'єкт GameManager, який керує станом гри.
    //enemiesAlive: кількість живих ворогів в поточний момент.
    //waves: масив хвиль, де кожна хвиля містить інформацію про ворогів, кількість і швидкість з'явлення.
    //spawnPoint: точка спавну, де вороги з'являються.
    //timeBetweenWaves: час між хвилями ворогів.
    //countdown: лічильник, що відлічує час до наступної хвилі.
    //waveCountdownTimer: текстове поле, яке відображає відлік часу до наступної хвилі.
    //waveIndex: поточний індекс хвилі.
    //Основна логіка цього коду полягає в наступному:

    //У методі Update перевіряється, чи є ще живі вороги або чи гра закінчена.Якщо так, то виконання методу припиняється.
    //Перевіряється, чи всі хвилі ворогів вже спавнено. Якщо так, викликається метод WinLevel() об'єкта gameManager і вимикається цей компонент.
    //Якщо лічильник countdown досягає нуля, починається нова хвиля ворогів.
    //У методі SpawnWave з'являються вороги один за одним з визначеним інтервалом часу.
    //У методі SpawnEnemy створюється новий ворог в заданій точці спавну.
    //Цей код керує генерацією хвиль ворогів та виконує їх спавн у відповідні моменти гри.
    #endregion

    private void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if(GameManager.gameIsOver)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
