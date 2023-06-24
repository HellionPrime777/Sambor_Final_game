using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#region
//код відповідає за анімацію відображення кількості пройдених раундів.

//Основні функції коду включають наступне:

//Задається змінна roundsText, яка представляє текстове поле, в якому відображатиметься кількість пройдених раундів.
//В методі OnEnable() виконується початок корутини AnimateText(). Це дозволяє почати анімацію при включенні цього скрипту.
//У корутині AnimateText() спочатку встановлюється текстове поле roundsText в значення "0".
//Після чеку на протязі 0.7 секунди, починається цикл, який змінює значення roundsText від 0 до значення PlayerStats.rounds.
//Кожного кроку циклу значення roundsText збільшується на одиницю і відображається на екрані.
//При цьому цикл чекає 0.055 секунди перед кожним оновленням значення.
//Коли значення roundsText досягає PlayerStats.rounds, анімація завершується.
//Отже, цей код створює ефект анімації збільшення числа пройдених раундів на екрані протягом певного часу.
#endregion

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while(round < PlayerStats.rounds)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.055f);
        }
    }
}
