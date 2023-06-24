using UnityEngine;

#region
//код визначає шлях для руху ворогів у грі. Основний елемент коду включає наступне:

//points: масив точок(Transform), які утворюють шлях.
//Awake(): метод, який викликається перед початком гри. В цьому методі масив points заповнюється всіма дочірніми об'єктами (точками) даного об'єкта (Waypoints).
//Кожна дочірня точка зберігається у відповідному елементі масиву points.
//Отже, цей код дозволяє зберігати та отримувати доступ до точок, які утворюють шлях для руху ворогів у грі. Це може використовуватись для програмування логіки руху ворогів вздовж визначеного шляху.
#endregion

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;

    void Awake ()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
