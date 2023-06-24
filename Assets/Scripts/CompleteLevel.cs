using UnityEngine;

#region
//код представляє клас "CompleteLevel" (Завершення рівня) у грі.Основні функції, які він виконує:


//Зберігає посилання на об'єкт "SceneFader", який відповідає за переходи між сценами гри з анімацією затемнення.
//Визначає назву наступного рівня (nextLevel) та номер рівня, який треба розблокувати (levelToUnlock).
//У методі "OnEnable" перевіряє, чи номер рівня, який треба розблокувати, більший за найвищий розблокований рівень, збережений у PlayerPrefs.Якщо так, то оновлює значення levelReached у PlayerPrefs, щоб розблокувати новий рівень.
//У методі "Continue" запускає анімацію затемнення за допомогою SceneFader та переходить до наступного рівня.
//У методі "Quit" відображає повідомлення "Quit" у консолі та закриває додаток.
//Основна функція цього класу полягає в управлінні завершенням рівня, переходом до наступного рівня, розблокуванням нових рівнів та управлінні переходом між сценами гри.
#endregion

public class CompleteLevel : MonoBehaviour
{
   

    public string nextLevel = "Level2";
    public int levelToUnlock = 2;

    public void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }

   

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
