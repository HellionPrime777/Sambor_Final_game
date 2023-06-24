using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //    код відповідає за обробку подій, пов'язаних з екраном завершення гри. Основні функції коду наступні:

    //Задається посилання на компонент SceneFader, який відповідає за перехід до інших сцен.
    //Метод Retry() викликається при натисканні кнопки "Retry" на екрані завершення гри.Він викликає метод FadeTo() компонента SceneFader,
    //    передаючи йому назву поточної сцени (SceneManager.GetActiveScene().name). Це викликає плавний перехід до тієї ж самої сцени, що дозволяє гравцю спробувати рівень знову.

    public SceneFader sceneFader;

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
