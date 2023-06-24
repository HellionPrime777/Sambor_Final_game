using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    #region
    //    код відповідає за ефект переходу між сценами, використовуючи затемнення(fade) зображення.

    //Основні функції коду включають наступне:

    //Задається змінна img, яка представляє зображення, що використовується для затемнення.
    //У методі Start() починається корутина FadeIn(), яка затемнює зображення при запуску сцени.
    //У методі FadeTo(string scene) починається корутина FadeOut(string scene), яка затемнює зображення перед переходом до наступної сцени.
    //У корутині FadeIn() значення альфа-каналу зображення змінюється з максимального (1) до нуля впродовж часу.Крива анімації curve використовується для згладжування зміни альфа-каналу.
    //У корутині FadeOut(string scene) значення альфа-каналу зображення змінюється з нуля до максимального (1) впродовж часу.Крива анімації curve використовується для згладжування зміни альфа-каналу.
    //Після завершення затемнення, метод LoadScene(string scene) здійснює перехід до нової сцени.
    //Отже, цей код додає ефект затемнення зображення для плавного переходу між сценами.
    #endregion

    IEnumerator FadeIn()
    {
        float t = 1f;
        
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0.03921569f, 0.5137255f, 0.5960785f, a);
            yield return 0;
        }
    }


    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0.03921569f, 0.5137255f, 0.5960785f, a);
            yield return 0;
        }


        SceneManager.LoadScene(scene);
    }
}
