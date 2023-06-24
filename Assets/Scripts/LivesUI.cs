using UnityEngine;
using UnityEngine.UI;

//код відповідає за оновлення тексту, що відображає кількість залишилися життів гравця, і забезпечує відображення актуальних даних на екрані.

public class LivesUI : MonoBehaviour
{
    public Text livesText;
    
    void Update()
    {
        livesText.text = PlayerStats.lives + " LIVES";
    }
}
