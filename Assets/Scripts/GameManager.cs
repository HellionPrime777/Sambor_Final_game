using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public GameObject completeLevelUi;

    private void Start()
    {
        gameIsOver = false;
    }

    #region
    //    код відповідає за керування станом гри і включає наступні функції:

    //Визначається статична змінна gameIsOver, що вказує, чи завершена гра.
    //Задається посилання на об'єкт gameOverUI, який відображається при завершенні гри.
    //Задається назва наступного рівня(nextLevel) та рівень, який потрібно розблокувати(levelToUnlock).
    //Задається посилання на компонент SceneFader, який відповідає за перехід до інших сцен.
    //Задається посилання на об'єкт completeLevelUi, який відображається при успішному завершенні рівня.
    //У методі Start встановлюється початковий стан гри, gameIsOver встановлюється в false.
    //У методі Update перевіряється натискання клавіші "L". Якщо так, викликається метод EndGame(), який завершує гру.
    //Перевіряється стан гри.Якщо gameIsOver встановлено в true, виконується return і виконання решти коду припиняється.
    //Якщо кількість залишених життів гравця(PlayerStats.lives) становить 0 або менше, викликається метод EndGame().
    //Метод EndGame() встановлює значення gameIsOver в true та активує об'єкт gameOverUI, який відображає екран завершення гри.
    //Метод WinLevel() встановлює значення gameIsOver в true та активує об'єкт completeLevelUi, який відображає екран успішного завершення рівня.
    //Отже, цей код відповідає за керування станом гри, включаючи перевірку на закінчення гри, перемогу на рівні та відображення відповідних екранів інтерфейсу.
    #endregion

    void Update()
    {
        if(Input.GetKeyDown("l"))
        {
            EndGame();
        }

        if(gameIsOver)
        {
            return;
        }
        if(PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUi.SetActive(true);
    }
}
