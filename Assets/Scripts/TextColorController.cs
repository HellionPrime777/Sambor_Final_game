using UnityEngine;
using UnityEngine.UI;

//код дозволяє змінювати колір тексту при наведенні курсору миші на об'єкт, що має текстовий компонент.

public class TextColorController : MonoBehaviour
{
    public Text infoText;
    private Color infoTextColor;
    public Color enterColor = new Color(1f, 0f, 0f);

    void Start()
    {
        infoTextColor = infoText.color;
    }

    private void OnMouseEnter()
    {
        infoText.color = enterColor;
    }

    private void OnMouseExit()
    {
        infoText.color = infoTextColor;
    }
}
