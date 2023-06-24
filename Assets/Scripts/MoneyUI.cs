using UnityEngine;
using UnityEngine.UI;

//код відповідає за оновлення тексту, що відображає кількість грошей гравця, і забезпечує відображення актуальних даних на екрані.

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    void Update()
    {
        moneyText.text = "$" + PlayerStats.money.ToString();
    }
}
